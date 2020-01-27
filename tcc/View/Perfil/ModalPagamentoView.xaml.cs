﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using tcc.ViewModel.Cliente;
namespace tcc.View.Perfil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalPagamentoView : ContentPage
    {
        public ModalPagamentoView()
        {
            InitializeComponent();
            BindingContext = new ModalPagamentoVM();
        }
    }
}