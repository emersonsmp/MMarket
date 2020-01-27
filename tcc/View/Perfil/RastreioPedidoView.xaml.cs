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
    public partial class RastreioPedidoView : ContentPage
    {
        public RastreioPedidoView()
        {
            InitializeComponent();
            BindingContext = new RastreioPedido();
        }
    }
}