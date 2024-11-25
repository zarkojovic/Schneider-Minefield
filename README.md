# Schneider MineField

**Schneider MineField** is a console-based game where the player navigates through a grid filled with mines to reach the exit. The game offers various difficulty levels, challenging the player to avoid mines and strategically plan their moves to survive and win.

---

## 📋 Table of Contents

- [Installation](#installation)
- [Usage](#usage)
- [Game Rules](#game-rules)
- [Difficulty Levels](#difficulty-levels)
- [Contributing](#contributing)
- [License](#license)
- [Future Features](#future-features)
- [Unit Tests](#unit-tests)

---

## 🚀 Installation

### Step 1: Clone the Repository

To clone the repository, run the following command:

```bash
git clone https://github.com/zarkojovic/Schneider_MineField.git
```

### Step 2: Open the Solution in Visual Studio

Navigate to the project folder:

```bash
cd Schneider_MineField
```

### Step 3: Build the Solution

- Open the solution in **Visual Studio**.
- Build the project to restore dependencies and compile the application.

---

## 🎮 Usage

### Step 1: Run the Application

Run the game using **Visual Studio** or the command line:

```bash
dotnet run --project Schneider_MineField
```

### Step 2: Set Up the Game

Follow the on-screen prompts:

- Enter the grid's width and height.
- Choose a difficulty level: `Easy`, `Medium`, or `Hard`.

### Step 3: Play the Game

Use the following keys to navigate:

- `W` - Move up
- `A` - Move left
- `S` - Move down
- `D` - Move right

The goal is to reach the **Exit (E)** without stepping on any **Mines (M)**!

---

## 📝 Game Rules

1. The player starts at the **top-left corner** of the grid.
2. The **Exit (E)** is randomly placed on the grid.
3. Mines (`M`) are randomly distributed based on the chosen difficulty.
4. Players have a limited number of lives:
   - Hitting a mine reduces one life.
5. The game ends when:
   - The player reaches the **Exit**, or
   - The player runs out of lives.

---

## 🔥 Difficulty Levels

| Level      | Mine Density       |
| ---------- | ------------------ |
| **Easy**   | 1 mine per 8 cells |
| **Medium** | 1 mine per 6 cells |
| **Hard**   | 1 mine per 4 cells |

---

## 🤝 Contributing

Contributions are welcome! If you'd like to improve this project:

1. Fork the repository.
2. Create a new branch for your feature or fix.
3. Commit your changes and push them to your fork.
4. Open a pull request describing your changes.

---

## 📜 License

This project is licensed under the MIT License. See the `LICENSE` file for more details.

---

## 🚀 Future Features

Here are some features that could be added in future versions of **Schneider MineField**:

- **Saving and Reading the Score**: Implement functionality to save the player's score to a JSON file and read it back during gameplay. This would allow players to track their progress across multiple sessions.
- **Dependency Injection Container**: Introduce a dependency injection container to manage object dependencies, making the code more modular and testable.
- **Observer Design Pattern**: Implement an observer pattern for handling player movements. This could be used for logging moves, triggering animations, or notifying other game components of the player's actions.

- **Custom Map Designing**: Allow players to design custom maps for the game, enabling them to create personalized levels with different mine placements and grid sizes.

By incorporating these features, we aim to enhance the gameplay experience and add more flexibility and scalability to the game. Feel free to contribute ideas or help implement these features!

---

## 🧪 Unit Tests

This project includes **unit tests** to ensure better quality assurance and maintainability of the codebase. The tests are designed to verify core game mechanics such as:

- Correct grid initialization
- Proper mine placement
- Player movement logic
- Boundary checks and more.

You can run the tests using the following command:

```bash
dotnet test
```

Unit tests help us catch potential issues early, improve the game's reliability, and ensure the expected behavior of game features. Contributions to extend the test suite are highly encouraged!
