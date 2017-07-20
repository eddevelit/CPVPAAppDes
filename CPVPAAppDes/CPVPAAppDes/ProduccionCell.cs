﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace CPVPAAppDes
{
    class ProduccionCell : ViewCell
    {
        public ProduccionCell()
        {

            var IdProduccionLabel = new Label
            {
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };
            IdProduccionLabel.SetBinding(Label.TextProperty, new Binding("IdProduccion"));

            var CantidadLabel = new Label
            {
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };
            CantidadLabel.SetBinding(Label.TextProperty, new Binding("Cantidad"));
            var PresentacionLabel = new Label
            {
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };
            PresentacionLabel.SetBinding(Label.TextProperty, new Binding("Presentacion"));
            var SaborLabel = new Label
            {
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.End,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };
            SaborLabel.SetBinding(Label.TextProperty, new Binding("Sabor"));

             View = new StackLayout
            {
                Children =
                {
                    IdProduccionLabel, CantidadLabel, PresentacionLabel, SaborLabel
                },
                Spacing = 0,
                Padding = 10,
                Orientation = StackOrientation.Horizontal
                

            };
        }
    }
}