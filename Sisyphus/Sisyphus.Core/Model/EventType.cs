namespace Sisyphus.Core.Model
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Describes the type of event - probably redundant now
    /// </summary>
    public enum EventType
    {
        [Display(Name = "Story Event")]
        Story,
        [Display(Name = "Decision Event")]
        Decision,
        [Display(Name = "Story Start Event")]
        StoryStart
    }
}