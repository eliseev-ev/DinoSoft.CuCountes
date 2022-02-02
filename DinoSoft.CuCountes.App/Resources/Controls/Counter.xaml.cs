namespace DinoSoft.CuCountes.App.Resources.Controls;

public partial class Counter : ContentView
{
	ViewModels.CounterVM CounterVM = new ViewModels.CounterVM(
	new Model.Counter
	{
		Name = "123",
		Value = 1
	});

	public Counter()
	{
		InitializeComponent();

	}
}