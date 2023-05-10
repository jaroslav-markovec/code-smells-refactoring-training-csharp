namespace VideoStore;

public class Movie
{
    public const int Children = 2;
    public const int Regular = 0;
    public const int NewRelease = 1;

    private readonly string _title;
    private int _priceCode;

    public Movie(string title, int priceCode)
    {
        _title = title;
        _priceCode = priceCode;
    }

    public int GetPriceCode()
    {
        return _priceCode;
    }

    public void SetPriceCode(int code)
    {
        _priceCode = code;
    }

    public string GetTitle()
    {
        return _title;
    }
}