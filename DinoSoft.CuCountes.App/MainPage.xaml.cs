namespace DinoSoft.CuCountes.App;

public partial class MainPage : ContentPage
{
	int count = 0;

	Model.Counter Counter = new Model.Counter
	{
		Name = "123",
		Value = 1
	};

	ViewModels.CounterVM CounterVM = new ViewModels.CounterVM(
		new Model.Counter
		{
			Name = "123",
			Value = 1
		});


	public MainPage()
	{
		InitializeComponent();

	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;
		CounterLabel.Text = $"Current count: {count}";

		SemanticScreenReader.Announce(CounterLabel.Text);
	}
}

