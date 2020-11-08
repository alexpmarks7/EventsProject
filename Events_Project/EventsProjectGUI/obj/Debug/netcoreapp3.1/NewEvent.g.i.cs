// Updated by XamlIntelliSenseFileGenerator 08/11/2020 09:49:16
#pragma checksum "..\..\..\NewEvent.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "73755EDB145DC47ECDB410FDA4D024371183E61A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using EventsProjectGUI;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace EventsProjectGUI
{


	/// <summary>
	/// NewEvent
	/// </summary>
	public partial class NewEventWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
	{

		private bool _contentLoaded;

		/// <summary>
		/// InitializeComponent
		/// </summary>
		[System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
		public void InitializeComponent()
		{
			if (_contentLoaded)
			{
				return;
			}
			_contentLoaded = true;
			System.Uri resourceLocater = new System.Uri("/EventsProjectGUI;V1.0.0.0;component/newevent.xaml", System.UriKind.Relative);

#line 1 "..\..\..\NewEvent.xaml"
			System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
		[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
		[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		internal System.Windows.Controls.Label Fixture;
		internal System.Windows.Controls.Label Venue;
		internal System.Windows.Controls.Label City;
		internal System.Windows.Controls.Label Country;
		internal System.Windows.Controls.Label Capacity;
		internal System.Windows.Controls.Label Date;
		internal System.Windows.Controls.Label Time;
		internal System.Windows.Controls.Label TicketsSold;
		internal System.Windows.Controls.TextBox FixtureInfo;
		internal System.Windows.Controls.TextBox VenueInfo;
		internal System.Windows.Controls.TextBox CityInfo;
		internal System.Windows.Controls.TextBox CountryInfo;
		internal System.Windows.Controls.TextBox CapacityInfo;
		internal System.Windows.Controls.TextBox DateInfo;
		internal System.Windows.Controls.TextBox TimeInfo;
		internal System.Windows.Controls.TextBox TicketsSoldInfo;
		internal System.Windows.Controls.Button EditEvent;
		internal System.Windows.Controls.ComboBox NewVenue;
		internal System.Windows.Controls.ComboBox SportBox;
		internal System.Windows.Controls.Button AddEvent;
		internal System.Windows.Controls.Button RemoveEvent;
	}
}

