namespace CryproApp.Commands
{
    internal class NavigateMarketCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            if (parameter is string url && !string.IsNullOrEmpty(url))
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
        }
    }
}
