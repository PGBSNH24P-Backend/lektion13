---
author: Lektion 13
date: MMMM dd, YYYY
paging: "%d / %d"
---

# Lektion 13

Hej och välkommen!

## Dagens agenda

1. Frågor och repetition
2. Repetition och fortsättning Identity Core
3. Eventuellt introduktion till testning
4. Övning med handledning

---

# Fråga

Kan du visa i ett av dina projekt (code alongs), hur man kodar en frontend i både js och react, hur man loggar in med identity core och jwt, genom en webbsida. dvs visuellt ui. vill kunna bygga portfölj med säker inloggning, men i ett mer verklighets troget scenario/applikation. Antingen nu eller när du har gått igenom komplett information för identity core och jwt.

# Svar

Vi fortsätter på mini-reddit på fredag antagligen, med säkerhet nu och sedan testning också. Vi hinner kanske med både React och JS, men inte säkert.

---

# Vad är testning?

- Skriv kod för att kolla annan kod
- Säkerställ krav, hitta fel och buggar
- Kör tester automatiskt
- Typer:
  - Unit
  - Integration
  - Performance
  - User
- XUnit för unit tester i C#
- Moq för mocking i C#

---

# Varför testning?

Vi kan testa vår kod själva, manuellt, men detta tar tid och vi missar saker.

Med kodtester kan vi göra detta automatiskt.

Testning kan bidra till mer flexibel kod (OOP, interfaces, mocking).

---

# Pitfalls och blind spots

- Testning hittar inte alla buggar
- Testning löser inte alla problem
- Testning kan skapa en falsk trygghetskänsla
- Testning kan leda till överkomplicering och over-abstraction
- Testning är också arbete och tar tid - ibland mycket mer tid
- Tester måste underhållas och dokumenteras

---

# Introduktion till XUnit

- Ett testramverk för C#
- Metoder för tester (med parametrar)
- Lifecycles för startups och cleanups
- Klasser för organisering
- Annotationer för data och dokumentation
- Assertions för villkor och tester
- I C# brukar tester ligga i ett separat projekt

---

# XUnit exempel

```csharp
using Xunit;

public class CalculatorTests
{
    [Fact]
    public void AddTwoNumbers_ReturnsCorrectSum()
    {
        // Arrange
        Calculator calculator = new Calculator();
        
        // Act
        int result = calculator.Add(5, 3);
        
        // Assert
        Assert.Equal(8, result);
    }
}
```

---

# Termer och begrepp

**Test:**

En egen funktion som testar en specifik del av kod. Ett test består ofta av flera "assertions".

**Assertion:**

En funktion som gör själva "testet" genom att jämföra värden. Exempel: equals, contains, not null, is true

**Unit:**

En individuell enhet av kod som kan testas, ofta en funktion eller klass. En 'unit' har ingen exakt definition, men ofta innebär mindre enheter enklare testning.

---

# Termer och begrepp

**Red & green:**

Ett sätt att beskriva resultatet av ett kört test. Green = success, red = fail.

**Refactor:**

Att gå tillbaka och ändra koden efter att ett test lyckas.

**Lifecycle:**

Funktioner som körs innan och efter tester, kan användas för cleanup, och setup.

---

# Termer och begrepp

**Given, When & Then:**

Ett sätt att strukturera upp tester.

Given = data
When = kör funktioner att testa
Then = gör assertions

**Arrange, Act & Assert:**

Ett annat namn för given, when & then.

Arrange <=> Given
Act <=> When
Assert <=> Then

**Mocking:**

Ett sätt att isolera komponenter för enklare unit testing. Det är oftast till för att koppla bort ett beroende, som en databas eller en service.

---

# Vad är unit testing?

- Testa mindre, individuella delar kod
- Ofta funktioner och ibland mindre klasser
- Kan göras när som helst, tidig bugghantering
- Verifierar att komponenter fungerar i isolation
- Säkerställer att krav är definierade
- Kan användas som dokumentation
- Kan hjälpa till med design av kod

---

# Enheter och beroenden

Komponenter har ofta beroende på andra komponenter (controller -> service, service -> repository, repository -> databas). Detta kan göra unit testning svårt.

- Försök ha så få beroenden som möjligt
- Ta kontroll över de beroenden som finns genom mocking
- Många ansvar är väldigt svårt att testa
- Funktioner med globala parametrar är svåra att testa

---

# Mocking

- Beroenden kan kontrolleras genom 'mocking'
- Skapa "fake" komponenter som agerar som riktiga komponenter
- I C# finns 'Moq' som ramverk

---

# Vad är integration testing?

- Testa att hela system fungerar
- Testa att flera enheter fungerar tillsammans
- Ofta funktioner med koppling till flera andra funktioner (service -> repository)
- Kräver mer arbete innan det kan utföras, men får med mycket mer
- Testar verklig användning

---

# Metoder för integration testing

1. **Top-down:** börja med att testa övre komponenter och gå nedåt (controller -> repository)
2. **Bottom-down:** börja med att testa nedre komponenter och gå uppåt (repository -> controller)
3. **Hybrid:** mixa top-down och bottom-up
4. **Big-bang:** testa endast de övre komponenterna (controller)

---

# Test-driven utveckling (TDD)

- Skriv tester först, och sedan vanlig kod
- Kräver med planering och tydlig struktur
- Färre buggar och problem
- Automatiskt flexibel kod och API:er
- Annat val av design
- Ta mer tid på grund av extra planering

---

# Skapa ett XUnit projekt

```sh
# Skapa XUnit projekt
dotnet new xunit

# Ladda ned Moq för mocking
dotnet add package Moq

# Inkludera ditt projekt för testning
dotnet add reference ../my-project

# Kör tester
dotnet test
```
