namespace InsiderNepalApp.ViewModel;

public class AdminPanelVM
{
    public Dictionary<string,int> countingnews { get;set; }

    public AdminPanelVM()
    {
        countingnews = new Dictionary<string, int>();
    }
}
