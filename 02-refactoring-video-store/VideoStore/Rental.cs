namespace VideoStore;

public class Rental
{
    public Rental(Movie movie, int daysRented) {
        _movie = movie;
        _daysRented = daysRented;
    }

    public int GetDaysRented() {
        return _daysRented;
    }

    public Movie GetMovie() {
        return _movie;
    }

    private readonly Movie _movie;
    private readonly int _daysRented;
}