﻿using System.Collections.Generic;
using Besenica.DAL;
using Besenica.Models;

namespace Besenica.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var countries = new List<Country>();

            //# C# Dictionary ISO {countrycode, countryname} list
            Dictionary<string, string> countryCodeCountryNameDict = new Dictionary<string, string>() { { "AD", "Andorra" }, { "AE", "United Arab Emirates" }, { "AF", "Afghanistan" }, { "AG", "Antigua and Barbuda" }, { "AI", "Anguilla" }, { "AL", "Albania" }, { "AM", "Armenia" }, { "AN", "Netherlands Antilles" }, { "AO", "Angola" }, { "AQ", "Antarctica" }, { "AR", "Argentina" }, { "AS", "American Samoa" }, { "AT", "Austria" }, { "AU", "Australia" }, { "AW", "Aruba" }, { "AX", "Åland Islands" }, { "AZ", "Azerbaijan" }, { "BA", "Bosnia and Herzegovina" }, { "BB", "Barbados" }, { "BD", "Bangladesh" }, { "BE", "Belgium" }, { "BF", "Burkina Faso" }, { "BG", "Bulgaria" }, { "BH", "Bahrain" }, { "BI", "Burundi" }, { "BJ", "Benin" }, { "BL", "Saint Barthélemy" }, { "BM", "Bermuda" }, { "BN", "Brunei Darussalam" }, { "BO", "Bolivia, Plurinational State of" }, { "BQ", "Bonaire, Sint Eustatius and Saba" }, { "BR", "Brazil" }, { "BS", "Bahamas" }, { "BT", "Bhutan" }, { "BV", "Bouvet Island" }, { "BW", "Botswana" }, { "BY", "Belarus" }, { "BZ", "Belize" }, { "CA", "Canada" }, { "CC", "Cocos (Keeling) Islands" }, { "CD", "Congo, the Democratic Republic of the" }, { "CF", "Central African Republic" }, { "CG", "Congo" }, { "CH", "Switzerland" }, { "CI", "Côte d'Ivoire" }, { "CK", "Cook Islands" }, { "CL", "Chile" }, { "CM", "Cameroon" }, { "CN", "China" }, { "CO", "Colombia" }, { "CR", "Costa Rica" }, { "CS", "Czechoslovak Socialist Republic" }, { "CU", "Cuba" }, { "CV", "Cape Verde" }, { "CW", "Curaçao" }, { "CX", "Christmas Island" }, { "CY", "Cyprus" }, { "CZ", "Czech Republic" }, { "DD", "German Democratic Republic" }, { "DE", "Germany" }, { "DJ", "Djibouti" }, { "DK", "Denmark" }, { "DM", "Dominica" }, { "DO", "Dominican Republic" }, { "DZ", "Algeria" }, { "EC", "Ecuador" }, { "EE", "Estonia" }, { "EG", "Egypt" }, { "EH", "Western Sahara" }, { "ER", "Eritrea" }, { "ES", "Spain" }, { "ET", "Ethiopia" }, { "FI", "Finland" }, { "FJ", "Fiji" }, { "FK", "Falkland Islands (Malvinas)" }, { "FM", "Micronesia, Federated States of" }, { "FO", "Faroe Islands" }, { "FR", "France" }, { "GA", "Gabon" }, { "GB", "United Kingdom" }, { "GD", "Grenada" }, { "GE", "Georgia" }, { "GF", "French Guiana" }, { "GG", "Guernsey" }, { "GH", "Ghana" }, { "GI", "Gibraltar" }, { "GL", "Greenland" }, { "GM", "Gambia" }, { "GN", "Guinea" }, { "GP", "Guadeloupe" }, { "GQ", "Equatorial Guinea" }, { "GR", "Greece" }, { "GS", "South Georgia and the South Sandwich Islands" }, { "GT", "Guatemala" }, { "GU", "Guam" }, { "GW", "Guinea-Bissau" }, { "GY", "Guyana" }, { "HK", "Hong Kong" }, { "HM", "Heard Island and McDonald Islands" }, { "HN", "Honduras" }, { "HR", "Croatia" }, { "HT", "Haiti" }, { "HU", "Hungary" }, { "ID", "Indonesia" }, { "IE", "Ireland" }, { "IL", "Israel" }, { "IM", "Isle of Man" }, { "IN", "India" }, { "IO", "British Indian Ocean Territory" }, { "IQ", "Iraq" }, { "IR", "Iran, Islamic Republic of" }, { "IS", "Iceland" }, { "IT", "Italy" }, { "JE", "Jersey" }, { "JM", "Jamaica" }, { "JO", "Jordan" }, { "JP", "Japan" }, { "KE", "Kenya" }, { "KG", "Kyrgyzstan" }, { "KH", "Cambodia" }, { "KI", "Kiribati" }, { "KM", "Comoros" }, { "KN", "Saint Kitts and Nevis" }, { "KP", "Korea, Democratic People's Republic of" }, { "KR", "Korea, Republic of" }, { "KW", "Kuwait" }, { "KY", "Cayman Islands" }, { "KZ", "Kazakhstan" }, { "LA", "Lao People's Democratic Republic" }, { "LB", "Lebanon" }, { "LC", "Saint Lucia" }, { "LI", "Liechtenstein" }, { "LK", "Sri Lanka" }, { "LR", "Liberia" }, { "LS", "Lesotho" }, { "LT", "Lithuania" }, { "LU", "Luxembourg" }, { "LV", "Latvia" }, { "LY", "Libya" }, { "MA", "Morocco" }, { "MC", "Monaco" }, { "MD", "Moldova, Republic of" }, { "ME", "Montenegro" }, { "MF", "Saint Martin (French part)" }, { "MG", "Madagascar" }, { "MH", "Marshall Islands" }, { "MK", "Macedonia, The Former Yugoslav Republic of" }, { "ML", "Mali" }, { "MM", "Myanmar" }, { "MN", "Mongolia" }, { "MO", "Macao" }, { "MP", "Northern Mariana Islands" }, { "MQ", "Martinique" }, { "MR", "Mauritania" }, { "MS", "Montserrat" }, { "MT", "Malta" }, { "MU", "Mauritius" }, { "MV", "Maldives" }, { "MW", "Malawi" }, { "MX", "Mexico" }, { "MY", "Malaysia" }, { "MZ", "Mozambique" }, { "NA", "Namibia" }, { "NC", "New Caledonia" }, { "NE", "Niger" }, { "NF", "Norfolk Island" }, { "NG", "Nigeria" }, { "NI", "Nicaragua" }, { "NL", "Netherlands" }, { "NO", "Norway" }, { "NP", "Nepal" }, { "NR", "Nauru" }, { "NU", "Niue" }, { "NZ", "New Zealand" }, { "OM", "Oman" }, { "PA", "Panama" }, { "PE", "Peru" }, { "PF", "French Polynesia" }, { "PG", "Papua New Guinea" }, { "PH", "Philippines" }, { "PK", "Pakistan" }, { "PL", "Poland" }, { "PM", "Saint Pierre and Miquelon" }, { "PN", "Pitcairn" }, { "PR", "Puerto Rico" }, { "PS", "Palestinian Territory, Occupied" }, { "PT", "Portugal" }, { "PW", "Palau" }, { "PY", "Paraguay" }, { "QA", "Qatar" }, { "RE", "Réunion" }, { "RO", "Romania" }, { "RS", "Serbia" }, { "RU", "Russian Federation" }, { "RW", "Rwanda" }, { "SA", "Saudi Arabia" }, { "SB", "Solomon Islands" }, { "SC", "Seychelles" }, { "SD", "Sudan" }, { "SE", "Sweden" }, { "SG", "Singapore" }, { "SH", "Saint Helena, Ascension and Tristan da Cunha" }, { "SI", "Slovenia" }, { "SJ", "Svalbard and Jan Mayen" }, { "SK", "Slovakia" }, { "SL", "Sierra Leone" }, { "SM", "San Marino" }, { "SN", "Senegal" }, { "SO", "Somalia" }, { "SR", "Suriname" }, { "SS", "South Sudan" }, { "ST", "Sao Tome and Principe" }, { "SU", "U.S.S.R." }, { "SV", "El Salvador" }, { "SX", "Sint Maarten (Dutch part)" }, { "SY", "Syrian Arab Republic" }, { "SZ", "Swaziland" }, { "TC", "Turks and Caicos Islands" }, { "TD", "Chad" }, { "TF", "French Southern Territories" }, { "TG", "Togo" }, { "TH", "Thailand" }, { "TJ", "Tajikistan" }, { "TK", "Tokelau" }, { "TL", "Timor-Leste" }, { "TM", "Turkmenistan" }, { "TN", "Tunisia" }, { "TO", "Tonga" }, { "TR", "Turkey" }, { "TT", "Trinidad and Tobago" }, { "TV", "Tuvalu" }, { "TW", "Taiwan, Province of China" }, { "TZ", "Tanzania, United Republic of" }, { "UA", "Ukraine" }, { "UG", "Uganda" }, { "UM", "United States Minor Outlying Islands" }, { "US", "United States" }, { "UY", "Uruguay" }, { "UZ", "Uzbekistan" }, { "VA", "Holy See (Vatican City State)" }, { "VC", "Saint Vincent and the Grenadines" }, { "VE", "Venezuela, Bolivarian Republic of" }, { "VG", "Virgin Islands, British" }, { "VI", "Virgin Islands, U.S." }, { "VN", "Viet Nam" }, { "VU", "Vanuatu" }, { "WF", "Wallis and Futuna" }, { "WS", "Samoa" }, { "YD", "People's Democratic Republic of Yemen" }, { "YE", "Yemen" }, { "YT", "Mayotte" }, { "YU", "Yugoslavia" }, { "ZA", "South Africa" }, { "ZM", "Zambia" }, { "ZR", "Zaire" }, { "ZW", "Zimbabwe" } };

            foreach (var countryCodeCountryName in countryCodeCountryNameDict)
            {
                string countryCode = countryCodeCountryName.Key;
                string countryName = countryCodeCountryName.Value;


                Country country = new Country()
                {
                    Name = countryName,
                    Hint = countryCode
                };

                countries.Add(country);
            }

            countries.ForEach(s => context.Countries.Add(s));
            context.SaveChanges();

            // Animals
            List<Animal> animals = new List<Animal>() {};
            Dictionary<string, string> animalName = new Dictionary<string, string>
            {
                { "Caiman", "Podobno na Krokodil"},
                { "Bison", "Mnogo golqmo chiftokopitno"},
                { "Alligator", "Podobno na Krokodil"},
                { "Mouse", "mickey mouse e jivotno?"},
                { "Scorpion", "Jili s otrowa"},
                { "Flamingo", "Krasifo pernato"},
                { "Donkey", "Podobno na kon"},
                { "Albatross", "Ptica"},
            };

            foreach (var animal in animalName)
            {
                Animal country = new Animal()
                {
                  Name = animal.Key,
                  Hint = animal.Value
                };

                animals.Add(country);
            }

            animals.ForEach(a => context.Animals.Add(a));
            context.SaveChanges();


            List<GameResult> gameResults = new List<GameResult>()
            {
                  new GameResult() {Answer = new Answer() {AnimalId = 1}, Guesses = 6, IsAnswered = false, Duration = DateTime.UtcNow, CreatedOn = DateTime.UtcNow, UserName = "Kiril2"},
                 new GameResult() {Answer = new Answer() {CountryId = 2}, Guesses = 2, IsAnswered = true, Duration = DateTime.UtcNow, CreatedOn = DateTime.UtcNow, UserName = "Kiril3"},
                  new GameResult() {Answer = new Answer() {CountryId = 4}, Guesses = 1, IsAnswered = true, Duration = DateTime.UtcNow, CreatedOn = DateTime.UtcNow, UserName = "Kiril4"}
            };

            gameResults.ForEach(x => context.GameResults.Add(x));
        }
}
}
