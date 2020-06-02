using CatFishingWebSite.Model;

namespace CatFishingWebSite.Services
{
    interface ISockets
    {
        User LoginUser(string username, string password);

        string Create(string username,string firstname, int age,string password, string gender, int sxepf);

        string GetFisher(int id);

        string EditFisher(int id, int sexpf, string password, string email, string description, bool isActive);

        void Logout();

        //Match

        string GetMatchList(int id);

        string Like(int otherId);

        string Reject( int otherId);

        //History
        string GetHis();
    }
}
