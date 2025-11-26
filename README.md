# Doofus Adventure – HW_2025_Test

A 3D game prototype built in Unity for the **Hitwicket – Game Developer Assignment (VIT 2025)**.
The game reads gameplay configuration from a JSON file ("Doofus Diary") and creates a dynamic
platform challenge where Doofus must survive by stepping on disappearing pulpits.

---

## 🎮 Gameplay Overview

Doofus is a cube that moves across floating platforms (“pulpits”). Each pulpit has a limited
lifetime and disappears after a specific duration.

### Game Rules

* Move using **WASD** or **Arrow Keys**
* Only **two pulpits** can exist at a time
* Each pulpit:

  * Has a **random destroy time** (loaded from JSON)
  * Spawns the **next pulpit** after a configurable delay (from JSON)
* Stepping on a new pulpit increases the **score**
* Falling off results in **Game Over**

---

## 📁 Project Structure

```
Assets/
 ├── Scripts/
 │     ├── GameManager.cs
 │     ├── DoofusController.cs
 │     ├── Pulpit.cs
 │     ├── CameraFollow.cs
 │     ├── ConfigLoader.cs
 │     ├── UIManager.cs
 │     ├── SceneLoader.cs
 │     └── EndScreenUI.cs
 ├── StreamingAssets/
 │     └── doofus_diary.json
 ├── Scenes/
 │     ├── StartScene.unity
 │     ├── GameScene.unity
 │     └── EndScene.unity
 └── Prefabs/
       └── Pulpit.prefab
```

---

## ▶️ How to Play

1. Launch **StartScene**
2. Press the **Play** button
3. Move Doofus using **WASD** / **Arrow Keys**
4. Move from pulpit to pulpit before they disappear
5. Score increases with every new pulpit touched
6. If you fall → End Scene loads and final score is displayed

---

## 🧠 Levels Implemented

### ✔ Level 1 – Movement + JSON Config

* Player movement uses values from `doofus_diary.json`
* Pulpit spawn/destroy logic based on JSON timing
* Only 2 pulpits active at a time

### ✔ Level 2 – Scoring

* Raycast checks pulpit under Doofus
* Score increments only when stepping on a **new** pulpit
* Score UI updates in real time

### ✔ Level 3 – Start & End Screens

* Start Scene with **Play** button
* End Scene showing **Final Score**
* **Restart** button returning to Start Scene

---

## 📝 JSON Configuration (Doofus Diary)

Example:

```
{
  "player_data": {
    "speed": 5.0
  },
  "pulpit_data": {
    "min_pulpit_destroy_time": 2,
    "max_pulpit_destroy_time": 5,
    "pulpit_spawn_time": 1.5
  }
}
```

Gameplay values load dynamically at runtime.

---

## 💻 Running the Project

1. Use **Unity 6+**
2. Clone the repo:

```
git clone https://github.com/<your-username>/HW_2025_Test
```

3. Open project in Unity Hub
4. Open **StartScene** and press **Play**

---

## 🖼 Screenshots / Gameplay

<img width="1458" height="727" alt="image" src="https://github.com/user-attachments/assets/98158685-5c2d-4b04-aa83-c241e1e97231" />
<img width="1467" height="717" alt="image" src="https://github.com/user-attachments/assets/bc4a3031-13af-4daa-b136-6fddbfbcfa11" />
<img width="1465" height="729" alt="image" src="https://github.com/user-attachments/assets/f99ee9a3-f1b1-43ed-9f19-86ec8947691c" />
<img width="1461" height="730" alt="image" src="https://github.com/user-attachments/assets/93a0d59c-5d5f-47bc-a777-f760031a648e" />
## VIDEO

https://github.com/user-attachments/assets/fa0fe5f5-9f12-4190-aaa7-4ed5a0865b0f



* Start Screen
* In-game pulpits
* Score UI
* Game Over screen

---

## 👤 Developer

**Anvesha (VIT – CSE)**
Game Development & Unity Enthusiast
Assignment for **Hitwicket – Game Developer (2025)**
