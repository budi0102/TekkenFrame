using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;

namespace TekkenFrame.ViewModels
{
	public class MainPageViewModel : BindableBase
	{
		public MainPageViewModel()
		{
			_stringMove = null;
			ParseCommand = new DelegateCommand(ParseCommand_Execute);
			TekkenLibrary.GlobalSettings.Instance.Language = TekkenLibrary.Language.Japanese;
		}

		public string InputText
		{
			get { return _inputText; }
			set { SetProperty(ref _inputText, value); }
		}
		private string _inputText;
		public string OutputText
		{
			get { return _outputText; }
			set { SetProperty(ref _outputText, value); }
		}
		private string _outputText;
		/// <summary>
		/// Language
		/// </summary>
		public string Language
		{
			get { return TekkenLibrary.GlobalSettings.Instance.Language.ToString(); }
			set
			{
				TekkenLibrary.GlobalSettings.Instance.Language = TekkenLibrary.Language.Parse(value);
				RaisePropertyChanged();
			}
		}

		public ICommand ParseCommand { get; private set; }
		private void ParseCommand_Execute()
		{
			if (TekkenLibrary.Command.TryParse(InputText, out _stringMove))
			{
				OutputText = _stringMove.ToString();
			}

		}

		private TekkenLibrary.Command _stringMove;
	}
}
