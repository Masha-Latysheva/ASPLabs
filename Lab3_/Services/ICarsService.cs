using Lab3_.ViewModels;

namespace Lab3_.Services
{
    public interface ICarsService
    {
        HomeViewModel GetHomeViewModel(int numberRows = 10);
    }
}