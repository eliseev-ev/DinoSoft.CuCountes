namespace DinoSoft.CuCounters.BlazorApp.Infrastructure
{
    public class RefreshToken
    {
        private List<Action> refreshActions;

        public RefreshToken(List<Action> refreshActions = null)
        {
            if (refreshActions != null)
            {
                this.refreshActions = refreshActions.ToList();
            }
            else
            {
                this.refreshActions = new List<Action>();
            }
        }

        public RefreshToken Next() => new RefreshToken(refreshActions);

        public void Add(Action refreshAction)
        {
            refreshActions.Add(refreshAction);
        }

        public void Refresh()
        {
            refreshActions.ForEach(x => x.Invoke());
        }
    }
}
