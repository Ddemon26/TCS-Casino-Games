# TCS Casino Games

![License](https://img.shields.io/badge/license-MIT-blue.svg) ![Version](https://img.shields.io/badge/version-1.0.0-brightgreen) ![Unity](https://img.shields.io/badge/Unity-2021.3+-black)
![GitHub Last Commit](https://img.shields.io/github/last-commit/Ddemon26/TCS-Casino-Games) ![GitHub Issues](https://img.shields.io/github/issues/Ddemon26/TCS-Casino-Games) ![GitHub Pull Requests](https://img.shields.io/github/issues-pr/Ddemon26/TCS-Casino-Games)

## Overview

**TCS Casino Games** is an extensive compendium of casino-style games implemented in C#. The repository encapsulates modular and scalable implementations of popular casino games, including Blackjack, Roulette, and Slots. The design aims to serve as an educational tool, a foundational platform for casino-themed game development, or as a resource for integrating casino game components into larger gaming environments. The project is architected with an emphasis on object-oriented programming paradigms, facilitating straightforward extensibility and maintainability.

## Games Included

- **Blackjack**: A card game where the objective is to achieve a hand value as close to 21 as possible without exceeding it, while competing against the dealer.
- **Roulette**: A renowned game of chance involving a spinning wheel, a ball, and the opportunity to bet on numbers or colors.
- **Slots**: The ubiquitous slot machine game featuring a set of reels and diverse symbols, providing straightforward win conditions based on combinations.

## Features

- **Modular Game Architecture**: Each game is constructed as an independent module, allowing ease of extension, reuse, or integration into other projects.
- **Object-Oriented Implementation**: Key entities such as `Deck`, `Card`, `Player`, `Dealer`, and `Hand` are modeled as classes, providing a highly modular and reusable codebase.
- **Balance Management System**: Tracks player balance dynamically, with comprehensive payout rules corresponding to each game's outcomes.
- **Versatile Betting Mechanism**: Allows users to place variable bet amounts for each game session, offering a flexible gaming experience.
- **Comprehensive Game Logic**: Implements intricate rules and mechanisms across multiple casino games, adhering to real-world gameplay conventions.

## Key Files

- **BlackjackGame.cs**: Contains the core logic for the Blackjack game, including player actions, dealer actions, and bet processing.
- **Card.cs, Deck.cs**: Fundamental representations of playing cards and decks, integral to the game mechanics of Blackjack.
- **Roulette & Slots**: Include similarly modular implementations, encapsulating the entities and game logic necessary to simulate authentic Roulette and Slot experiences.

## Getting Started

### Prerequisites

- **Unity 2021.3+**: The project is designed for integration with Unity, providing graphical interfaces and enhanced user interaction.
- **.NET Framework 4.x**: Necessary for compiling and executing the C# scripts included in this project.

### Installation

1. Clone the repository:

   ```sh
   git clone https://github.com/Ddemon26/TCS-Casino-Games.git
   ```

2. Open the project within Unity or load the scripts using any suitable C# development environment.

3. Ensure that all required dependencies, including Unity and relevant .NET packages, are correctly installed.

### Usage

- To integrate one of the casino games into a Unity project, import the corresponding script files from the `Runtime` folder.
- The provided classes are designed to facilitate straightforward integration. For instance, to run a game of Blackjack, instantiate the `BlackjackGame` class and invoke methods such as `StartRound()` to manage the flow of the game.

## Gameplay Description

### Blackjack

In Blackjack, the player begins with a defined starting balance and can wager a specified amount at the outset of each round. Both the dealer and player are initially dealt two cards, and the goal is for the player to achieve a hand value as close to 21 as possible without exceeding it. Standard Blackjack rules apply, including hit or stand decisions for both player and dealer, based on established game logic.

### Roulette

Roulette involves a spinning wheel with numbered slots, each slot colored either red or black. Players can place bets on individual numbers, color groups, or numeric ranges. Once the wheel is spun, the ball settles into one of the numbered slots, and the game processes payouts accordingly, depending on the type and nature of bets placed.

### Slots

The slot machine game simulates a conventional 3-reel slot mechanism. Players place a wager, spin the reels, and receive payouts based on the resultant combination of symbols that align across the payline. The game encompasses classic slot machine symbols, with payouts determined by predefined win conditions.

## Testing

Unit tests are available under the `Tests` directory. These tests are written using a C# testing framework to validate the core game mechanics, including the shuffling of cards in Blackjack and outcome determination in Roulette. To execute the tests:

```sh
# Run using your preferred testing environment
```

## Contributing

Contributions to the project are highly encouraged. Whether suggesting improvements, identifying bugs, or expanding game functionality, please feel free to submit a pull request or open an issue to initiate a discussion. Contributions should maintain consistency with the existing structure and coding conventions.

## License

This project is distributed under the MIT License. For more detailed information, please see [LICENSE.md](LICENSE.md).
