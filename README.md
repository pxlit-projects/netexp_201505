# .NET Expert - Ruben Feyen (netexp_201505)

## Concept

Het concept is zeer eenvoudig: een app die mensen helpt om een parkeerplaats te vinden in Brussel.

Om dit te realiseren zal ik gebruik maken van open data die wordt aangeboden door de stad Brussel. Zowel de publieke parkings als de parkeerplaatsen voor gehandicapten komen aan bod, zodat iedereen een kans krijgt om een parkeerplaats te vinden.

Eveneens is er nood aan een API om adressen (en/of huidige locaties) van gebruikers om te zetten naar geografische coördinaten. Hiervoor zal ik hoogstwaarschijnlijk gebruik maken van de Google Maps Geocoding API.

De app moet zo eenvoudig mogelijk zijn om te gebruiken. Initieel wil ik ervoor zorgen dat mensen een adres kunnen ingeven, waarvoor de app dan de parkeerplaatsen teruggeeft die het dichtst bij zijn. Een eventuele uitbreiding (indien tijd en technologie het toelaten) zal zijn om de huidige geografische locatie van de gebruiker rechtstreeks te gebruiken. Op welke manier ik aan deze geografische locatie zal geraken is momenteel nog niet duidelijk.

Bovendien zal de gebruiker ook de kans krijgen om aan te geven of hij/zij al dan niet behoefte heeft aan een parkeerplaats voor gehandicapten. Op basis van deze keuze zal vervolgens één van de datasets van de stad Brussel worden geraadpleegd.

Indien haalbaar zou ik ook graag nog een routebeschrijving toevoegen in de vorm van een wegenkaart waarop de route is aangeduid. Hiervoor zou ik opnieuw gebruik maken van Google Maps.

## Referenties

### APIs

* Google Maps
 * [Embed API] (https://developers.google.com/maps/documentation/embed/)
 * [Geocoding API] (https://developers.google.com/maps/documentation/geocoding/)

### Datasets (Open Data)

* Open Data initiatief van de stad Brussel
 * [Public parkings] (http://opendata.brussel.be/explore/dataset/public-parkings/)
 * [Parking spaces for disabled] (http://opendata.brussel.be/explore/dataset/parking-spaces-for-disabled/)

