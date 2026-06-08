using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Data;
using System.IO;

namespace tools_médecin
{
    public class OrdonnancePdf
    {
        /// <summary>
        /// Génère un document PDF à partir des données d'une ordonnance.
        /// </summary>
        /// <param name="donnees">DataTable contenant les jointures Patient, Medecin et Medicaments</param>
        /// <param name="cheminFichier">Chemin complet de destination du fichier .pdf</param>
        public static void Generer(DataTable donnees, string cheminFichier)
        {
            // Application de la licence communautaire (obligatoire pour QuestPDF)
            QuestPDF.Settings.License = LicenseType.Community;

            // Extraction des informations globales (communes à toutes les lignes du DataTable)
            if (donnees.Rows.Count == 0) return;
            DataRow infos = donnees.Rows[0];

            // Création du document
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(11).FontFamily(Fonts.Arial));

                    // 1. EN-TÊTE : Informations du Médecin et de la Clinique
                    page.Header().Row(row =>
                    {
                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Text($"Dr. {infos["medecinNom"]}").FontSize(16).SemiBold().FontColor(Colors.Blue.Medium);
                            col.Item().Text($"{infos["specialite"]}").Italic();
                            col.Item().Text($"RPPS : {infos["numeroRPPS"]}");
                        });

                        row.RelativeItem().AlignRight().Column(col =>
                        {
                            col.Item().Text("CLINIQUE GSB").FontSize(14).Bold();
                            col.Item().Text(DateTime.Now.ToShortDateString());
                        });
                    });

                    // 2. CORPS DU DOCUMENT
                    page.Content().PaddingVertical(1, Unit.Centimetre).Column(col =>
                    {
                        // Bloc d'informations du Patient
                        col.Item().Background(Colors.Grey.Lighten4).Padding(10).Column(c =>
                        {
                            c.Item().Text($"Patient : {infos["patientNom"]} {infos["patientPrenom"]}").SemiBold();
                            c.Item().Text($"Né(e) le : {Convert.ToDateTime(infos["dateNaissance"]).ToShortDateString()}");
                            c.Item().Text($"N° Sécu : {infos["numeroSecu"]}");
                        });

                        col.Item().PaddingTop(1, Unit.Centimetre).Text("Prescription :").Underline().Bold();

                        // Tableau des lignes de médicaments
                        col.Item().PaddingTop(0.5f, Unit.Centimetre).Table(table =>
                        {
                            // Définition des 3 colonnes
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(3); // Médicament
                                columns.RelativeColumn(2); // Posologie
                                columns.RelativeColumn(1); // Durée
                            });

                            // Entête du tableau
                            table.Header(header =>
                            {
                                header.Cell().Element(CellStyle).Text("Médicament").Bold();
                                header.Cell().Element(CellStyle).Text("Posologie").Bold();
                                header.Cell().Element(CellStyle).Text("Durée").Bold();

                                static IContainer CellStyle(IContainer container)
                                {
                                    return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Black);
                                }
                            });

                            // Itération sur chaque ligne de médicament du DataTable
                            foreach (DataRow row in donnees.Rows)
                            {
                                table.Cell().Element(PaddingStyle).Text(row["medicamentNom"].ToString());
                                table.Cell().Element(PaddingStyle).Text(row["posologie"].ToString());
                                table.Cell().Element(PaddingStyle).Text(row["dureeJours"].ToString() + " jours");

                                static IContainer PaddingStyle(IContainer container)
                                {
                                    return container.PaddingVertical(5);
                                }
                            }
                        });
                    });

                    // 3. PIED DE PAGE
                    page.Footer().AlignCenter().Column(f => {
                        f.Item().LineHorizontal(1);
                        f.Item().PaddingTop(5).Text(x =>
                        {
                            x.Span("Document informatisé généré par l'application GSB - Page ");
                            x.CurrentPageNumber();
                        });
                    });
                });
            })
            .GeneratePdf(cheminFichier);

            // Ouverture automatique du PDF après l'enregistrement
            try
            {
                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(cheminFichier)
                {
                    UseShellExecute = true
                };
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                // En cas d'impossibilité d'ouvrir le fichier (ex: pas de lecteur PDF installé)
                throw new Exception("Le PDF a été créé mais n'a pas pu être ouvert automatiquement : " + ex.Message);
            }
        }
    }
}