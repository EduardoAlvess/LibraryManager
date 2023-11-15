namespace LibraryManager.Models.DTOs
{
    public record BookDTO(string Title, string Author, string ISBN, int ReleaseYear, int Stock);
}
