﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Techem.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterPage : TabbedPage
    {
		public MasterPage ()
		{
			InitializeComponent ();
		}
	}
}