# Unity Weekly Assignment – Full Project README

---

# 📝 Project Overview
This project contains **all required components** from **Part A** and **Part B** of the Unity weekly assignment.  
I built a complete demonstration scene for Part A, and a full 2D game-like environment for Part B, including player movement, minimap, and camera behavior.

Everything requested in the assignment is implemented and explained below section by section.

---

# 🅰 Part A — Components

## ✔ 1. Mover — Constant Movement Component
I created a `Mover` script that moves any GameObject at a **constant speed and direction**, fully adjustable using `SerializeField`.

---

## ✔ 2. Oscillator — Pendulum-Like Movement

I built an **Oscillator** using **Mathf.Sin**, producing realistic wave-like motion around a center point.

---

## ✔ 3. Rotator — Rotation on a Chosen Axis
I created a flexible `Rotator` component that rotates around any axis at a chosen rotation speed.

---

## ✔ 4. Heartbeat Object — Grow/Shrink Pulse

We implemented scale oscillation:
```
scale = baseScale * (1 + Mathf.Sin(time * speed) * intensity)
```
This achieves a real heart‑beat effect.

---

## ✔ 5. Hide/Show Toggle Component
A component was added that lets the player hide and show the object using a keyboard key.

- Toggles `Renderer.enabled`  
- Uses `SerializeField` to allow choosing the key  

Demonstrated with labels in the Part A scene.

---

## ✔ 6. Part A Demonstration Scene
A single clean scene contains:
- Mover  
- Oscillator  
- Rotator  
- Heartbeat  
- Hide/Show  
- TextMeshPro labels on every object  

---

# 🅱 Part B — Cameras and World Navigation

## ✔ 1. Player Movement in a 2D World
I created a functional mini-world where the player:
- Walks in 8 directions  
- Moves smoothly  
- Is tracked by a following camera  
---

## ✔ 2. Camera Follow with Movement Bounds
The camera smoothly follows the player using Lerp.  
We added **boundaries**, so the camera stops when reaching the map edges.

This prevents:
- Seeing outside the ground  
- Blue background glitches  
- Excessive camera movement  

---

## ✔ 3. Mini‑Map Implementation
We implemented a full minimap:
- A second orthographic camera  
- Positioned above the world  
- Shows only the world + player  
- Rendered in a small UI square  
- Player is always visible and appropriately scaled  

---

## ✔ 4. Simulator Rotation Behavior Explained
The assignment asks:

### **Why do objects look bigger when switching to portrait?**

Because:
> The **orthographicSize** of the camera remains constant,  
> but the **aspect ratio becomes narrower**, causing the camera to show less horizontal space.  
> With fewer world units visible, every object appears larger.

---

## ✔ 5. Fixing the Portrait/Landscape Scaling/Rotating Problem

the CameraFollow script itself automatically adjusts the camera’s orthographic Size.
Instead of having a separate script, the same component that:

follows the player

clamps the camera within map bounds

also includes the logic to modify the orthographic size whenever the aspect ratio changes.
---

# Author:
Aviv Neeman

Link to itch.io project: 

