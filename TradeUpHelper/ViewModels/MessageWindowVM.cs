using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TradeUpHelper.Models.TradeUpHelperAPI;

namespace TradeUpHelper.ViewModels
{
    class MessageWindowVM : ViewModelBase
    {

        public Visibility NextButtonVisibility { get; set; } = Visibility.Visible;
        public Visibility BackButtonVisibility { get; set; } = Visibility.Hidden;

        private int _currentMessageIndex = 1;
        public int CurrentMessageIndex
        {
            get
            {
                return _currentMessageIndex;
            }
            set
            {
                _currentMessageIndex = value;
                if (_currentMessageIndex == 1)
                {
                    BackButtonVisibility = Visibility.Hidden;
                    NextButtonVisibility = Visibility.Visible;
                }else if(_currentMessageIndex == Messages.Count)
                {
                    BackButtonVisibility = Visibility.Visible;
                    NextButtonVisibility = Visibility.Hidden;
                }
                else
                {
                    BackButtonVisibility = Visibility.Visible;
                    NextButtonVisibility = Visibility.Visible;
                }
            }
        }
        public BindingList<MessageForUser> Messages { get; set; }
        public MessageForUser CurrentMessage { get; set; } = null;
        public MessageWindowVM()
        {// MessageBox.Show("gg"); 
        }
        public MessageWindowVM(List<MessageForUser> messages)
        {
            Messages = new BindingList<MessageForUser>(messages);
            CurrentMessage = Messages[CurrentMessageIndex - 1];
        }

        public ICommand bNextMessage
        {
            get
            {
                return new RelayCommand(() =>
                {
                    // MessageBox.Show(Messages.Count.ToString());
                    if (CurrentMessageIndex < Messages.Count)
                    {
                        // MessageBox.Show(Messages[CurrentMessageIndex - 1].Title);
                        CurrentMessageIndex++;
                        CurrentMessage = Messages[CurrentMessageIndex - 1];
                    }

                });
            }
        }

        public ICommand bBackMessage
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (CurrentMessageIndex > 1)
                    {
                        CurrentMessageIndex--;
                        CurrentMessage = Messages[CurrentMessageIndex - 1];
                    }
                });
            }
        }
    }
}
