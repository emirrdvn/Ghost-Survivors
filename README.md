# Ghost Survivors - Unity WebGL Game

Play the game here: [Ghost Survivors on Itch.io](https://emirrdvn.itch.io/ghost-survivors)

Ghost Survivors is a thrilling Unity WebGL game where you must survive waves of ghostly enemies using a combination of strategic movement, fireball attacks, and powerful special abilities. This README outlines the game's features, developer contributions, and gameplay mechanics.

---

## Gameplay

In Ghost Survivors, your objective is to survive for as long as possible while defeating waves of ghost enemies. The gameplay is intuitive and action-packed, with the following mechanics:  

- **Movement**: Navigate the environment using `W`, `A`, `S`, and `D` keys.  
- **Jumping**: Press `Space` to jump and evade enemies.  
- **Fireball Attack**: Use **Left Click** to shoot fireball projectiles at enemies.  
- **Special Ability**: Trigger a devastating "rain of fire" ability with **Right Click** to deal massive damage to multiple enemies at once.  

### Player Health
- The player starts with **100 Health Points (HP)**.  
- Each collision with a ghost enemy reduces the player's health by **10 HP**.  
- The game ends when the player’s health reaches **0 HP**.

Survive as long as possible by dodging enemies and utilizing your abilities strategically.

---

## Developer Contributions

### Emir Rıdvan Toraman - 22360859061
- **Player Movement and Character Control PlayerMovement:sc56 Controller Move with Vector3**: Implemented smooth movement mechanics and ensured ground control to prevent flying.  
- **Jumping and Ground Control PlayerMovement:sc44 Physics.checkSphere used**: Added jumping functionality for vertical movement.  
- **Fireball Attack Mechanic (Left Click) Weapon:sc47 Instantiate and RigidBody Addforce**: Developed the shooting system with Rigidbody-based projectile movement.  
- **Enemy Movement EnemyMovement:sc28 Vector3.MoveTowards**: Designed AI behavior for enemies to navigate toward the player.  
- **Mouse Movement Restriction MouseMovement:sc28 Mathf.Clamp**: Limited mouse movement to the game window for enhanced control.  
- **Bullet Destruction Weapon:sc56 Coroutine**: Set a timer for bullet objects to self-destruct after a specific duration to optimize performance.  

### Arda Aydın Kılınç - 21360859039
- **Mouse Look and Interaction MouseMovement:sc32 Quaternion.Euler**: Integrated mouse-based camera control for player-environment interaction.  
- **Special Ability (Right Click) Weapon:sc37 Instantiate with UnityEngine.Random**: Designed and implemented the powerful "rain of fire" ability.  
- **Enemy Spawn System SpawnManager:sc25 Instatiate randomly with Coroutine**: Created a dynamic spawning system for enemies.  
- **Enemy Rotation EnemyMovement:sc55 Quaternion.LookRotation**: Programmed enemies to rotate and face the player during interactions.  
- **Enemy Death&BulletCollision& Enemy Death Effects EnemyMovement:sc78 OnTriggerEnter**: Added visual and sound effects for enemy deaths.  
- **Player HP System PlayerMovement:sc77 Damage()**: Developed a health points system to track and display the player's health and manage game-over conditions.  

---

## Assets Used

The following Unity Asset Store assets were used in the game. We appreciate the creators for their contributions:

1. **[Snowed Fence](https://assetstore.unity.com/packages/3d/environments/snowed-fence-6722)**  
   Used for environmental decoration to enhance the winter-themed setting.  

2. **[Low Poly Simple Nature Pack](https://assetstore.unity.com/packages/3d/environments/landscapes/low-poly-simple-nature-pack-162153)**  
   Provided low-poly nature assets for a visually engaging landscape.  

3. **[Ghost Character (Free)](https://assetstore.unity.com/packages/3d/characters/creatures/ghost-character-free-267003)**  
   Utilized as the enemy character model in the game.  

4. **[3D Items Free Wand Pack](https://assetstore.unity.com/packages/3d/props/weapons/3d-items-free-wand-pack-46225)**  
   Used for player shooting mechanics with stylized wand models.  

---

## Developers

- [adraarda23](https://github.com/adraarda23)  
- [emirrdvn](https://github.com/emirrdvn)

Thank you for playing Ghost Survivors!  
For any feedback or inquiries, please contact us through the Itch.io page.
