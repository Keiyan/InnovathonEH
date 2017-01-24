using EulerHermesInnovathon.Models.Button;
using EulerHermesInnovathon.Models.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EulerHermesInnovathonApi.Repositories
{
    public class DataRepository
    {
        private static object __sync = new object();
        private static DataRepository __Instance;

        public static DataRepository Instance
        {
            get
            {
                if (__Instance == null)
                    lock (__sync)
                        if (__Instance == null)
                            __Instance = new DataRepository();
                return __Instance;
            }
        }

        private IEnumerable<EmergencyResponse> _responseList = new List<EmergencyResponse>()
        {
            new EmergencyResponse(
                new Category("Défacement de site", "Le visuel de votre site web a été remplacé par des images choquantes ou portant atteinte à votre image"),
                new Warranty("Restauration de données", 500000, 20000, "Vos données ont été détruites, remplacées ou rendues innaccessibles. Vous avez recours à un expert pour relancer le système à partir des sauvegardes"),
                new List<PartnerQuote>()
                {
                    new PartnerQuote("Kaspersky",450),
                    new PartnerQuote("Sekoïa"   ,475),
                    new PartnerQuote("Alcyd"    ,600),
                }),
            new EmergencyResponse(
                new Category("Cyber extorsion", "Vos SI sont bloqués et un fraudeur exige une rançon."),
                new Warranty("Cyber Extorsion", 1000000, 50000, "Vos SI sont bloqués et un fraudeur exige une rançon. Vous avez recours à un expert pour tenter de débloquer le système"),
                new List<PartnerQuote>()
                {
                    new PartnerQuote("Sekoïa"   ,400),
                    new PartnerQuote("Kaspersky",450),
                    new PartnerQuote("Alcyd"    ,600),
                }),
            new EmergencyResponse(
                new Category("Hacking et perte de données", "Des individus se sont introduits dans votre système pour voler ou détruire des données"),
                new Warranty("Restauration de données", 750000, 15000, "Vos données ont été détruites, remplacées ou rendues innaccessibles. Vous avez recours à un expert pour relancer le système à partir des sauvegardes."),
                new List<PartnerQuote>()
                {
                    new PartnerQuote("Alcyd"    ,400),
                    new PartnerQuote("Sekoïa"   ,430),
                    new PartnerQuote("Kaspersky",450),
                }),
            new EmergencyResponse(
                new Category("Détournement frauduleux", "Des individus se sont introduits dans votre système et ont réalisé un détournement de fonds."),
                new Warranty("Détournement frauduleux", 300000, 100000, "Des individus se sont introduits dans votre système et ont réalisé un détournement de fonds."),
                new List<PartnerQuote>()
                {
                    new PartnerQuote("Sekoïa"   ,500),
                    new PartnerQuote("Kaspersky",800),
                }),
            new EmergencyResponse(
                new Category("Autres", "Votre problème ne correspond à aucune des catégories ci-dessus"),
                new Warranty("Piratage", 6666666, 42, "La garantie piratage courve toutes conséquences de cyber attaques et cyber fraudes."),
                new List<PartnerQuote>()
                {
                    new PartnerQuote("Sekoïa"   ,1000),
                }),
        };

        private IEnumerable<Package> _packageList = new List<Package>()
        {
            new Package("Détournement frauduleux", 500, "Des individus se sont introduits dans votre système et ont réalisé un détournement de fonds."),
            new Package("Cyber extorsion", 700, "Vos SI sont bloqués et un fraudeur exige une rançon. Vous avez recours à un expert pour tenter de débloquer le système"),
            new Package("Décontamination", 1000, "Vos données sont atteintes par un virus. Vous avez recours à un expert pour tenter de décontaminer le système."),
            new Package("Restauration de données", 300, "Vos données ont été détruites, remplacées ou rendues innaccessibles. Vous avez recours à un expert pour relancer le système à partir des sauvegardes."),
            new Package("Piratage téléphonique", 200, "L'utilisation frauduleuse de vos systèmes de téléphonie génère des surconsommations."),
            new Package("Frais de communication/notification", 3000, "<Vous engagez des frais de communication aux personnes dont les données à caractère personnelles détenues dans vos SI ont été atteinte."),
        };

        private IEnumerable<Enterprise> _enterpriseList = new List<Enterprise>()
        {
            new Enterprise("678502444", "ROHL", 6700000, 30, "2740Z", false, "Fabrication d'éclairage", null),
        };

        public IEnumerable<T> GetAll<T>()
        {
            var targetType = typeof(T);
            if (targetType == typeof(EmergencyResponse)) return (IEnumerable<T>)this._responseList;
            if (targetType == typeof(Package)) return (IEnumerable<T>)this._packageList;
            if (targetType == typeof(Enterprise)) return (IEnumerable<T>)this._enterpriseList;

            return null;
        }
    }
}