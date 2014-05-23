using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Laboras22.ViewModels.Users;
using MahApps.Metro.Controls;
using System.Security;
using Laboras22.ValidationRules;

namespace Laboras22.Views
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : MetroWindow
    {
        private RegisterViewModel m_RegisterViewModel;
        private PasswordValidationRule m_PasswordValidationRule;
        private ConfirmPasswordValidationRule m_ConfirmPasswordValidationRule;

        public RegisterWindow()
        {
            InitializeComponent();

            m_RegisterViewModel = new RegisterViewModel();
            m_LayoutRoot.DataContext = m_RegisterViewModel;
            SetupPasswordValidation();
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!IsUserInputValid())
            {
                return;
            }

            m_RegisterViewModel.Register();
        }
        
        private bool IsUserInputValid()
        {
            return !Validation.GetHasError(m_UserNameTextBox) &&
                   !Validation.GetHasError(m_PasswordBox) &&
                   !Validation.GetHasError(m_ConfirmPasswordBox) &&
                   !Validation.GetHasError(m_EmailTextBox) &&
                   !Validation.GetHasError(m_FirstNameTextBox) &&
                   !Validation.GetHasError(m_LastNameTextBox) &&
                   !Validation.GetHasError(m_AliasTextBox);
        }

        private void SetupPasswordValidation()
        {
            m_PasswordValidationRule = new PasswordValidationRule();
            m_ConfirmPasswordValidationRule = new ConfirmPasswordValidationRule(m_PasswordBox);

            m_PasswordBox.Tag = m_PasswordBox.PasswordChar;
            var validationBinding = new Binding { Source = m_PasswordBox, Path = new PropertyPath("Tag") };
            validationBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(m_PasswordBox, PasswordBox.PasswordCharProperty, validationBinding);

            m_ConfirmPasswordBox.Tag = m_ConfirmPasswordBox.PasswordChar;
            validationBinding = new Binding { Source = m_ConfirmPasswordBox, Path = new PropertyPath("Tag") };
            validationBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(m_ConfirmPasswordBox, PasswordBox.PasswordCharProperty, validationBinding);
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var validationResult = m_PasswordValidationRule.Validate(m_PasswordBox.Password, null);
            var bindingExpression = m_PasswordBox.GetBindingExpression(PasswordBox.PasswordCharProperty);

            if (validationResult.IsValid)
            {
                m_RegisterViewModel.Password = m_PasswordBox.SecurePassword;
                Validation.ClearInvalid(bindingExpression);
            }
            else
            {
                var validationError = new ValidationError(m_PasswordValidationRule, bindingExpression, validationResult.ErrorContent, null);
                Validation.MarkInvalid(bindingExpression, validationError);
            }
        }

        private void ConfirmPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var validationResult = m_ConfirmPasswordValidationRule.Validate(m_ConfirmPasswordBox.Password, null);
            var bindingExpression = m_ConfirmPasswordBox.GetBindingExpression(PasswordBox.PasswordCharProperty);

            if (validationResult.IsValid)
            {
                m_RegisterViewModel.ConfirmPassword = m_ConfirmPasswordBox.SecurePassword;
                Validation.ClearInvalid(bindingExpression);
            }
            else
            {
                var validationError = new ValidationError(m_PasswordValidationRule, bindingExpression, validationResult.ErrorContent, null);
                Validation.MarkInvalid(bindingExpression, validationError);
            }
        }
    }
}