using API.Models;

namespace API.Interfaces
{
    public interface IReviewerInterface
    {
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewer(int id);
        ICollection<Review> GetReviewByReviewer(int reviewerId);
        bool ReviewerExists(int reviewerId);
    }
}
