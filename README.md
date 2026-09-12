# Mana Route
Vorhersage von Onlogist-Auftrags-Hotspots, damit nach einer lukrativen Fahrt mit hoher Wahrscheinlichkeit ein Rückauftrag nach NRW verfügbar ist. Datenquelle: Onlogist-Benachrichtigungsmails (Outlook, Microsoft Graph).

## Struktur

```
src/
  ManaRoute.Domain          Entitäten: Standort, Auftrag, Sichtung (keine Abhängigkeiten)
  ManaRoute.Application     Use Cases + Schnittstellen (Parser, Repositories)
  ManaRoute.Infrastructure  EF Core/PostGIS, Graph-Mailabruf, Mail-Parser
  ManaRoute.Api             REST-API für die spätere Blazor-PWA
  ManaRoute.Ingestion       Worker: ruft Mails ab und speichert Aufträge
tests/
  ManaRoute.Domain.Tests
  ManaRoute.Infrastructure.Tests   (Parser-Tests mit echten .eml-Dateien)
```

## Einrichtung

1. .NET SDK 10 und Docker Desktop installieren
2. `.env.example` nach `.env` kopieren und Passwort setzen
3. Datenbank starten: `docker compose up -d`
4. Pakete hinzufügen, bauen, testen: `pwsh ./scripts/add-packages.ps1`

## Roadmap

1. Parser (OnlogistMailParser + Tests)
2. Datenbank (DbContext, Migrationen, PostGIS)
3. Graph-Anbindung (Device-Code-Login, Delta-Abruf, Historie-Import)
4. Auswertung (Hotspots, Rückfahrt-Score)
5. Blazor-PWA mit Tourplaner und Push-Benachrichtigungen
