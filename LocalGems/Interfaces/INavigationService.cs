

namespace LocalGems.Interfaces
{
    public interface INavigationService
    {
        void GoTo(PageType pageType);
        void GoBack();
    }

    public enum PageType
    {
        HomePage,
        MyPostPage,
        ChatPage,
        InviteFriendsPage,
        NotificationPage,
        AboutUsPage,
        SupportPage,
        FaqPage
    }
}
