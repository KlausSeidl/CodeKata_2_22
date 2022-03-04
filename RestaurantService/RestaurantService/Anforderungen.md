Schreibe einen Service, um einen Tisch in einem Restaurant zu reservieren.
 
Ein Anwender möchte in einem Restaurant für x Personen zu einer gegebenen Uhrzeit für x Stunden einen Tisch reservieren.

* Der Service muss dem Anwender das Reservieren eines Tisches erlauben.
* Der Service muss dem Anwender das Reservieren eines Tisches zu einer bestimmten Uhrzeit erlauben
* Der Service muss dem Anwender das Reservieren eines Tisches mit einer bestimmten Zeitdauer erlauben.
* Der Service muss dem Anwender das Reservieren eines Tisches für eine Anzahl x von Personen erlauben.


Wenn kein Tisch frei ist, liefert der Service als Antwort eine "kein Tisch frei" Antwort.

* Der Service muss die Fähigkeit besitzen, den Reservierungsplan nach freien Tischen zu durchsuchen.
* Der Service muss die Verfügbarkeit eines freien Tisches prüfen können.
** Der Service muss bei der Verfügbarkeit des freien Tisches die Anzahl der Personen berücksichtigen
** Der Service muss bei der Verfügbarkeit des freien Tisches die Uhrzeit berücksichtigen
** Der Service muss bei der Verfügbarkeit des freien Tisches die Zeitspanne berücksichtigen 
* Der Service muss dem Anwender eine Antwort über den Erfolg der Reservierung liefern.
* Der Service muss dem Anwender eine Antwort über den Misserfolg der Reservierung liefern.


Wenn ein Tisch frei ist, wird die Reservierung in der Datenbank eingetragen und der Anwender erhält zusätzlich zur 
Antwort vom Service eine Bestätigungsemail.

* Der Service muss erfolgreiche Reservierungen in einer Datenbank speichern.
* Der Service muss dem Anwender eine Mail für erfolgreiche Reservierungen senden.
* Der Service muss dem Anwender eine Antwort über Erfolg der Reservierung geben.
* Der Service muss dem Anwender eine Antwort über Misserfolg der Reservierung geben.
** Bei Misserfolg sollte der Service dem Anwender einen Hinweis über das Reservierungsproblem liefern.
** Bei Misserfolg sollte der Service dem Anwender einen Alternativvorschlag zu seinem Reservierungswunsch anbieten.
