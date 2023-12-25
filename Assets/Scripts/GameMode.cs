
// класс, содержащий всю информацию о режиме игры, можно сделать ScriptableObject
public class GameMode
{
    private string _name;
    private string _recordName;

    public string name => this._name;
    public string recordName => this._recordName;

    public GameMode(string gameModeName)
    {
        _name = gameModeName;
        _recordName = gameModeName + "Record";
    }

    // нужно что-то ещё
}
