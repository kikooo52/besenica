# Besenica

MVC project - бесеница

Ако ги няма(Държавите и животните) трябва да се сииднат командата е: update-database -Verbose в "Tools > NuGet Package Manager > Package Manager Console command"

1 - Моделите
Animals - Хинтовете съм ги измислил да са тъпи

Countries - Имах ги свалени и реших да е с държави на не с градове. Хинтровете са съкращението на държавата(Bulgaria - bg)

GameResult - Има “Answer”, “UserName”, “Duration”, “Guesses”, “IsAnwered”.

Answer - Това е обща таблица за животните и държавите.

Game - Не е импементирано нищо с този модел, защото няма мутиплеър. Иначе записвам в нея 1 игра колко отговора има и кой юзър е започнал играта
 

2 - Само когато се логне юзър може да си отвори страницата за игра.
Проверявам дали е    @if (Request.IsAuthenticated)

3 - В javascripta съм си направил логиката на играта. Направил съм си сървис, който управлява цялата логика. Взимам държавите и животните, има възможност да си избираш категория. При край на играта записвам резултата.

4. Не съм завършил мултипреър, защото ще ми отнеме повече време, за сметка на това съм вкарал SignalR и може да се вижда кой юзър играе в момента и какви отговори прави от другата страна може някои да му дава съвети. :)


Имаш 6 а не 5 живота, повечето са така.

Източиниците ми са доста (http://stackoverflow.com/), гледал съм как е направена играта в различните и варянти.

