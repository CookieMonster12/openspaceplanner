namespace OpenSpace.Application.Entities;

public record Session(
    int Id,
    string Name,
    string CreatedAt,
    ICollection<Room> Rooms,
    ICollection<Slot> Slots,
    ICollection<Topic> Topics,
    ICollection<Survey> Surveys,
    bool VotingEnabled = false,
    bool FreeForAll = false,
    bool AttendanceEnabled = true,
    bool TeamsAnnouncementsEnabled = false);
