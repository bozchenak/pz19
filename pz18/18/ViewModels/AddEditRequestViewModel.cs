using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _18.Properties;

namespace _18
{
    public class AddEditRequestViewModel : BindableBase
    {
        private IClientRepository _clientRepository;

        public AddEditRequestViewModel(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
            SaveCommand = new RelayCommand(OnSave, CanSave);
            CancelCommand = new RelayCommand(OnCancel);
        }

        private bool _isEditeMode;
        public bool IsEditeMode
        {
            get => _isEditeMode;
            set => SetProperty(ref _isEditeMode, value);
        }

        private Clients _editingCustomer = null;
        private ValidableCustomer _customer;
        public ValidableCustomer Clients
        {
            get => _customer;
            set => SetProperty(ref _customer, value);
        }

        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }
        public event Action Done;

        //----------------

        private void OnCanExecuteChanges(object sender, EventArgs e)
        {
            SaveCommand.OnCanExecuteChanged();
        }

        private void CopyCustomer(Clients source, ValidableClients target)
        {
            target.Id = source.Id;
            if (IsEditeMode)
            {
                target.FirstName = source.FirstName;
                target.LastName = source.LastName;
                target.Email = source.Email;
                target.Phone = source.Phone;
            }
        }

        internal void SetCustomer(Clients customer)
        {
            _editingCustomer = customer;
            if (Customer != null)
                Customer.ErrorsChanged -= OnCanExecuteChanges;
            Customer = new ValidableClients();
            Customer.ErrorsChanged += OnCanExecuteChanges;
            CopyCustomer(customer, Customer);
        }

        internal void OnCancel()
        {
            Done?.Invoke();
        }
        private bool CanSave() => !Customer.HasErrors;

        private void UpdateCustomer(ValidableClients source, Clients target)
        {
            target.FirstName = source.FirstName;
            target.LastName = source.LastName;
            target.Email = source.Email;
            target.Phone = source.Phone;
        }

        private async void OnSave()
        {
            UpdateCustomer(Customer, _editingCustomer);
            if (IsEditeMode)
                await _clientRepository.UpdateCustomerAsync(_editingCustomer);
            else
                await _clientRepository.AddCustomerAsync(_editingCustomer);
            Done?.Invoke();
        }
    }
}
