# TileVania

A Metroidvania-style 2D platformer game developed using the Unity Game Engine.

## Overview

In TileVania, the player starts with 3 lives (hearts) and must collect coins while achieving the highest score possible. The game features sponge-like enemies that the player must fight or avoid.

When the player comes into contact with an enemy, they lose one life and restart the current level. If all 3 lives are lost, the player is sent back to Level 0.
## Screenshots

<img width="2560" height="1440" alt="Image" src="https://github.com/user-attachments/assets/46944410-6591-4bdb-bd77-ec755489c06e" />
<img width="2560" height="1440" alt="image" src="https://github.com/user-attachments/assets/d8c851dd-1d2f-4320-adbc-057640512204" />
<img width="2378" height="1332" alt="image" src="https://github.com/user-attachments/assets/741b7ab3-2feb-41f0-9721-7e6205c74548" />

## Features

- Character animations for shooting, running, climbing, and death
- Jumping and movement mechanics
- Mobility features such as ladders and mushrooms
- Dynamic camera system that follows the player during gameplay
- Multiple enemy variations (currently green and pink)
- Multiple levels with different environments
- Sound effects
- Coin collection and scoring system
- Life/heart system

## Technologies & Tools

- **C#** — Game scripting and logic
- **Unity** — Game engine
- **Piskel** — Pixel-art creation

## Controls

| Action | Key |
|---|---|
| Move Left | `A` / `←` |
| Move Right | `D` / `→` |
| Jump | `Space` |
| Shoot | `Left Mouse Button` |
| Climb Up | `W` / `↑` |
| Climb Down | `S` / `↓` |

## Project Structure

```text
TileVania/
├── Assets/
│   ├── Animations/          # Character and object animations
│   ├── Audio/               # Music and sound effects
│   ├── Fonts/               # Fonts used in the game
│   ├── Materials/           # Materials and shaders
│   ├── Prefabs/             # Reusable GameObjects
│   ├── Scenes/              # Game levels and scenes
│   ├── Scripts/             # C# game logic
│   ├── Settings/            # Game and graphics settings
│   ├── Sprites/             # 2D sprites and artwork
│   ├── TextMesh Pro/        # TextMesh Pro assets
│   └── Tiles/               # Tilemap and tile assets
│
├── Packages/                # Unity package dependencies
│   ├── manifest.json
│   └── packages-lock.json
│
├── ProjectSettings/         # Unity project configuration
│
└── README.md

## How to Run

1. Clone the repository:

```bash
git clone <https://github.com/tapascoder002007-jpg/TileVania>
```

2. Open **Unity Hub**.

3. Select **Add Project from Disk** and choose the cloned `TileVania` folder.

4. Open the project using the Unity version specified in `ProjectSettings/ProjectVersion.txt`.

5. Open the main scene from:

```text
Assets/Scenes/
```

6. Press **Play** in the Unity Editor to start the game.

## Credits

Developed by **[Tapas Dev Yadav]**.

This project was developed independently, with inspiration and learning resources from the Udemy course:

**Complete C# Unity 2D Game Development (Updated To Unity 6)**  
by GameDev.tv Team, Rick Davidson, and Ahmed Nassef.

The course was used as a learning resource and source of inspiration for developing the game.
