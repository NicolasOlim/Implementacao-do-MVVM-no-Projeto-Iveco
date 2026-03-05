namespace Iveco_Green_Ledger.Commands
{
	public class RelayCommand : ICommand
	{
		private readonly Action execute;
		private readonly Func<bool>? canExecute;

		public RelayCommand(Action execute, Func<bool> canExecute = null)
		{
			this.execute = execute;
			this.canExecute = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			return canExecute == null || canExecute();
		}

		public object Execute(object parameter)
		{
			execute();
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}
	}
}