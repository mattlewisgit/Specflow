namespace Vitality.Website.Areas.Presales.Handlers.SocialMedia
{
    public class SocialMediaCountsDto
    {
        public int Count { get; set; }

        public static SocialMediaCountsDto From(int count)
        {
            return new SocialMediaCountsDto
            {
                Count = count
            };
        }
    }
}
