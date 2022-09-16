CREATE DATABASE Biblioteca_Aziendale;
USE Biblioteca_Aziendale;

CREATE TABLE Libri 
(
    id INT IDENTITY(1,1) PRIMARY KEY,
    titolo VARCHAR(200),
    isbn VARCHAR(13),
    descrizione VARCHAR(5000),
    copertina VARCHAR(1000),
    nPagine INT,
    genere VARCHAR(50),
    scaffale VARCHAR(5),
    annoPubblicazione INT,
    casaEditrice VARCHAR(100)
)

CREATE TABLE Autori
(
    id INT IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(50),
    cognome VARCHAR(50),
    dob DATE
)

CREATE TABLE Utenti
(
    id INT IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(40),
    cognome VARCHAR(40),
    dob DATE,
    indirizzo VARCHAR(100),
    userAdmin BIT,
    username VARCHAR(100),
    psw VARCHAR(100)
)

CREATE TABLE ScrittoDa
(
    id INT IDENTITY(1,1) PRIMARY KEY,
    idLibro INT FOREIGN KEY REFERENCES Libri(id)
    ON UPDATE CASCADE
    ON DELETE CASCADE,
    idAutore INT FOREIGN KEY REFERENCES Autori(id)
    ON UPDATE CASCADE
    ON DELETE CASCADE
)

CREATE TABLE inPrestito
(
    id INT IDENTITY(1,1) PRIMARY KEY,
    dataInizio DATE,
    dataFine DATE,
    idUtente INT FOREIGN KEY REFERENCES Utenti(id)
    ON UPDATE CASCADE
    ON DELETE CASCADE,
    idLibro INT FOREIGN KEY REFERENCES Libri(id)
    ON UPDATE CASCADE
    ON DELETE CASCADE
)
INSERT INTO Libri
(titolo,isbn,descrizione,copertina,nPagine,genere,scaffale,annoPubblicazione,casaEditrice)
VALUES
('L''uomo più ricco di Babilonia','B077J1LBQK','Coltivate le vostre facoltà, studiate e diventate più saggi, acquisite maggiore abilità, agite rispettando voi stessi.','',170,'Business & Economics','A1',2017,'Gribaudi'),
('L''uomo più ricco di Babilonia','B077J1LBQK','Coltivate le vostre facoltà, studiate e diventate più saggi, acquisite maggiore abilità, agite rispettando voi stessi.','',170,'Business & Economics','A1',2017,'Gribaudi'),
('L''uomo più ricco di Babilonia','B077J1LBQK','Coltivate le vostre facoltà, studiate e diventate più saggi, acquisite maggiore abilità, agite rispettando voi stessi.','',170,'Business & Economics','A1',2017,'Gribaudi'),
('The Book Thief','9780375842207','Quando la Morte ha una storia da raccontare,tu ascolti. E'' il 1939. Germania Nazista. Il paese sta trattenendo il respiro. La Morte non è mai stata così impegnata,e lo sarà anche di più.','',608,'Fiction','A1',2007,'Alfred A. Knopf'),
('The Book Thief','9780375842207','Quando la Morte ha una storia da raccontare,tu ascolti. E'' il 1939. Germania Nazista. Il paese sta trattenendo il respiro. La Morte non è mai stata così impegnata,e lo sarà anche di più.','',608,'Fiction','A1',2007,'Alfred A. Knopf'),
('The Book Thief','9780375842207','Quando la Morte ha una storia da raccontare,tu ascolti. E'' il 1939. Germania Nazista. Il paese sta trattenendo il respiro. La Morte non è mai stata così impegnata,e lo sarà anche di più.','',608,'Fiction','A1',2007,'Alfred A. Knopf'),
('La mucca viola','8873392849','Che cosa hanno imprese internazionali come Apple, Google, Ikea o il macellaio italiano Dario Cecchini che la vostra azienda non ha? Le P tradizionali come prezzo, promozione, pubblicità, posizionamento e altre che gli uomini di marketing usano da tempo non funzionano più. Oggi, all''elenco, c''è da aggiungere un''altra P: quella di Purple Cow, la Mucca Viola. Che non è una funzione di marketing cui ricorrere a prodotto finito. La Mucca Viola spicca tra le tante marroni, è qualcosa di fenomenale, inatteso, che è dentro il prodotto. L''autore vi spiega come mettere una Mucca Viola in tutto ciò che fate e in tutto ciò che create, per sfornare prodotti che siano degni di marketing.','',128,'Business & Economics','A1',2011,'ROI Edizioni'),
('Intelligenza emotiva','9788817112994','L''intelligenza emotiva può essere descritta come la capacità di un individuo di riconoscere, di discriminare e identificare, di etichettare nel modo appropriato e, conseguentemente, di gestire le proprie emozioni e quelle degli altri allo scopo di raggiungere determinati obiettivi.','',486,'Auto-aiuto','A2',2011,'Rizzoli'),
('Intelligenza emotiva','9788817112994','L''intelligenza emotiva può essere descritta come la capacità di un individuo di riconoscere, di discriminare e identificare, di etichettare nel modo appropriato e, conseguentemente, di gestire le proprie emozioni e quelle degli altri allo scopo di raggiungere determinati obiettivi.','',486,'Auto-aiuto','A2',2011,'Rizzoli'),
('Intelligenza emotiva','9788817112994','L''intelligenza emotiva può essere descritta come la capacità di un individuo di riconoscere, di discriminare e identificare, di etichettare nel modo appropriato e, conseguentemente, di gestire le proprie emozioni e quelle degli altri allo scopo di raggiungere determinati obiettivi.','',486,'Auto-aiuto','A2',2011,'Rizzoli'),
('Il ritratto di Dorian Gray','9788807900587','Dorian Gray, un giovane di straordinaria bellezza, si è fatto fare un ritratto da un pittore. Ossessionato dalla paura della vecchiaia, ottiene, con un sortilegio, che ogni segno che il tempo dovrebbe lasciare sul suo viso, compaia invece solo sul ritratto. Avido di piacere, si abbandona agli eccessi più sfrenati, mantenendo intatta la freschezza e la perfezione del suo viso. Poiché Hallward, il pittore, gli rimprovera tanta vergogna, lo uccide. A questo punto il ritratto diventa per Dorian un atto d''accusa e in un impeto di disperazione lo squarcia con una pugnalata. Ma è lui a cadere morto: il ritratto torna a raffigurare il giovane bello e puro di un tempo e a terra giace un vecchio segnato dal vizio.','',142,'Classico','A2',2011,'Mondadori'),
('Il ritratto di Dorian Gray','9788807900587','Dorian Gray, un giovane di straordinaria bellezza, si è fatto fare un ritratto da un pittore. Ossessionato dalla paura della vecchiaia, ottiene, con un sortilegio, che ogni segno che il tempo dovrebbe lasciare sul suo viso, compaia invece solo sul ritratto. Avido di piacere, si abbandona agli eccessi più sfrenati, mantenendo intatta la freschezza e la perfezione del suo viso. Poiché Hallward, il pittore, gli rimprovera tanta vergogna, lo uccide. A questo punto il ritratto diventa per Dorian un atto d''accusa e in un impeto di disperazione lo squarcia con una pugnalata. Ma è lui a cadere morto: il ritratto torna a raffigurare il giovane bello e puro di un tempo e a terra giace un vecchio segnato dal vizio.','',142,'Classico','A2',2011,'Mondadori'),
('Le notti bianche','9788855440141','Le notti bianche, è un racconto giovanile di Fëdor Dostoevskij, pubblicato per la prima volta nel 1848, sulla rivista Otečestvennye zapiski, n. 12. L''opera prende il nome dal periodo dell''anno noto col nome di notti bianche, in cui nella Russia del nord, inclusa la zona di San Pietroburgo, il sole tramonta dopo le 22.','',176,'Fiction','A2',2011,'Feltrinelli'),
('Le notti bianche','9788855440141','Le notti bianche, è un racconto giovanile di Fëdor Dostoevskij, pubblicato per la prima volta nel 1848, sulla rivista Otečestvennye zapiski, n. 12. L''opera prende il nome dal periodo dell''anno noto col nome di notti bianche, in cui nella Russia del nord, inclusa la zona di San Pietroburgo, il sole tramonta dopo le 22.','',176,'Fiction','A2',2011,'Feltrinelli'),
('Il Barone Rampante','9788804668190','La storia del Barone Cosimo Piovasco di Rondò, indomabile ribelle che a dodici anni sale su un albero per non ridiscenderne mai più, è considerata uno dei capolavori di Calvino. Questa splendida versione, dedicata ai ragazzi, fu realizzata dall''autore nel 1959 mantenendo intatte la qualità della scrittura e la suggestione del racconto. Una storia piena di avventure, leggerezza e libertà.','',320,'Narrativa contemporanea','A3',2010,'Mondadori'),
('Il Barone Rampante','9788804668190','La storia del Barone Cosimo Piovasco di Rondò, indomabile ribelle che a dodici anni sale su un albero per non ridiscenderne mai più, è considerata uno dei capolavori di Calvino. Questa splendida versione, dedicata ai ragazzi, fu realizzata dall''autore nel 1959 mantenendo intatte la qualità della scrittura e la suggestione del racconto. Una storia piena di avventure, leggerezza e libertà.','',320,'Narrativa contemporanea','A3',2010,'Mondadori'),
('Il Barone Rampante','9788804668190','La storia del Barone Cosimo Piovasco di Rondò, indomabile ribelle che a dodici anni sale su un albero per non ridiscenderne mai più, è considerata uno dei capolavori di Calvino. Questa splendida versione, dedicata ai ragazzi, fu realizzata dall''autore nel 1959 mantenendo intatte la qualità della scrittura e la suggestione del racconto. Una storia piena di avventure, leggerezza e libertà.','',320,'Narrativa contemporanea','A3',2010,'Mondadori'),
('L''Arte di ricordare tutto','9788830432567','Quaranta giorni. È il tempo che ciascuno di noi spreca in media ogni anno per rimediare a ciò che dimentica: per andare a recuperare il cellulare lasciato chissà dove, per cercare le chiavi di casa o per rintracciare informazioni importanti. Joshua Foer rientrava a pieno titolo in questa media, ma dopo un anno di allenamento si è ritrovato alla finale del Campionato statunitense della memoria. Dunque la memoria si può davvero migliorare, chiunque può riuscire a imparare 1528 numeri a caso in un''ora e ricordarseli tutti, come il pluricampione del mondo Ben Pridmore.','',343,'Auto-aiuto','A3',2011,'Longanesi'),
('L''Arte di ricordare tutto','9788830432567','Quaranta giorni. È il tempo che ciascuno di noi spreca in media ogni anno per rimediare a ciò che dimentica: per andare a recuperare il cellulare lasciato chissà dove, per cercare le chiavi di casa o per rintracciare informazioni importanti. Joshua Foer rientrava a pieno titolo in questa media, ma dopo un anno di allenamento si è ritrovato alla finale del Campionato statunitense della memoria. Dunque la memoria si può davvero migliorare, chiunque può riuscire a imparare 1528 numeri a caso in un''ora e ricordarseli tutti, come il pluricampione del mondo Ben Pridmore.','',343,'Auto-aiuto','A3',2011,'Longanesi'),
INSERT INTO Autori
(nome,cognome,dob)
VALUES
('George Samuel','Clason','1874-11-7'),
('Markus','Zusak','1975-06-23'),
('Seth','Godin','1960-07-10'),
('Daniel','Goleman','1946-03-07'),
('Oscar','Wilde','1854-10-16'),
('Fëdor','Dostoevskij','1821-11-11'),
('Italo','Calvino','1923-10-15'),
('Joshua','Foer','1982-09-23');
