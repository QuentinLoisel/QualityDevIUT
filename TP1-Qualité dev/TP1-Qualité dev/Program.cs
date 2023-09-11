using System;
using System.Collections.Generic;
public class Media
{
    protected string Title { get; set; }
    protected int refNumber { get; set; }

    public int availableNumber { get; set; }

    public Media()
    {
        Title = string.Empty;
        refNumber = 0;
        availableNumber = 0;
    }

    public Media(string title, int numberReference, int numberAvailable)
    {
        Title = title;
        refNumber = numberReference;
        availableNumber = numberAvailable;
    }

    public virtual void AfficherInfos()
    {
        Console.WriteLine($"Titre: {Title}");
        Console.WriteLine($"Numéro de référence: {refNumber}");
        Console.WriteLine($"Nombre d'exemplaires disponibles: {availableNumber}");
    }

}

public class Livre : Media
{
    protected string author { get; set; }

    public Livre()
    {
        author = string.Empty;
    }

    public Livre(string title, int numberReference, int numberAvailable, string Author)
        : base(title, numberReference, numberAvailable)
    {
        author = Author;
    }

    public override void AfficherInfos()
    {
        base.AfficherInfos();
        Console.WriteLine($"Auteur: {author}");
    }
}

public class DVD : Media
{
    protected int duree { get; set; }
    public DVD()
    {
        duree = 0;
    }

    public DVD(string title, int numberReference, int numberAvailable, int dureeMinutes)
    : base(title, numberReference, numberAvailable)
    {
        duree = dureeMinutes;
    }

    public override void AfficherInfos()
    {
        base.AfficherInfos();
        Console.WriteLine($"Durée: {duree} minutes");
    }
}

public class CD : Media
{
    private string artist { get; set; }
    public CD()
    {
        artist = string.Empty;
    }

    public CD(string title, int numberReference, int numberAvailable, string Artist)
    : base(title, numberReference, numberAvailable)
    {
        artist = Artist;
    }

    public override void AfficherInfos()
    {
        base.AfficherInfos();
        Console.WriteLine($"Artiste: {artist}");
    }
}
public class Tools
{
    public static Media AddMedia(Media media, int nombreAjout)
    {
        media.availableNumber += nombreAjout;
        return media;
    }

    public static Media RemoveMedia(Media media, int nombreRetrait)
    {
        if (media.availableNumber < nombreRetrait)
        {
            throw new InvalidOperationException("Le nombre d'exemplaires disponibles est insuffisant pour effectuer le retrait.");
        }

        media.availableNumber -= nombreRetrait;
        return media;
    }
}
public class Library
{
    private List<Media> listMedia;

    public Library()
    {
        listMedia = new List<Media>();
    }

    public void DisplayMedia()
    {
        foreach (var media in listMedia)
        {
            media.AfficherInfos();
            Console.WriteLine();
        }
    }
}

public class monMain
{
    static void Main(string[] args)
    {
        Media monMedia = new Media("Mon Livre", 123, 5);
        Tools.AddMedia(monMedia, 3);
        monMedia.AfficherInfos();
    }
}

