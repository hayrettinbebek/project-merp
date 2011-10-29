﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace WpfApplication1.ViewModel {
    class WorkspaceViewModel : ViewModelBase{

        RelayCommand _closeCommand;
        //Geht ab wenn der Workspace vom UI weg soll

        public ICommand CloseCommand {
            get {
                if (_closeCommand == null)
                    _closeCommand = new RelayCommand(param => this.OnRequestClose());

                return _closeCommand;
            }
        }

        public event EventHandler RequestClose;


        void OnRequestClose() {
            EventHandler handler = this.RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

    }
}