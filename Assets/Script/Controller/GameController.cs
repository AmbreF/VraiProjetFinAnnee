using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    PlayerControls controls;


    [SerializeField] SecondView _secondView;
    [SerializeField] MinuteView _minuteView;


    [SerializeField] CharacterMovement characterMovement;
    [SerializeField] AimMovement characterAim;

    [SerializeField] CharacterProjectileSpawner characterProjectileSpawner;
    [SerializeField] CharacterProjectileSpawner characterProjectileSpawner2;
    [SerializeField] CharacterProjectileSpawner characterProjectileSpawner3;

    //[SerializeField] HeartView heart1;
    //[SerializeField] HeartView heart2;
    //[SerializeField] HeartView heart3;


    [SerializeField] PauseController pauseGame;

    [SerializeField] AuraModel aura;
    [SerializeField] CharacterModel character;

    [SerializeField] int nbBullet;

    private int nbShootBoost;

    [SerializeField] TimerModel _timerModel;




    // Start is called before the first frame update
    void Start()
    {
        _timerModel = new TimerModel(0, 3);

        _timerModel.GetSecond().Subscribe(_secondView);
        _timerModel.GetMinute().Subscribe(_minuteView);
        


        nbShootBoost = 1;

        if(nbBullet == 1)
        {
            characterProjectileSpawner.SetShoot(true);
        }else if (nbBullet == 2)
        {
            characterProjectileSpawner2.SetShoot(true);
            characterProjectileSpawner3.SetShoot(true);
        }
        else 
        {
            characterProjectileSpawner.SetShoot(true);
            characterProjectileSpawner2.SetShoot(true);
            characterProjectileSpawner3.SetShoot(true);
        }

    }

    // Update is called once per frame
    void Update()
    {

        _timerModel.ChangeTimer();


        if(character.GetAuraBoost())
        {
            aura.SetAuraBoost(true);
            character.SetAuraBoost(false);
        }

        /*
        if (character.GetLife())
        {

        }
        */






        if(nbBullet == 1 && character.GetShootBoost())
        {

            character.SetShotBoost(false);

            if(nbShootBoost%3 == 0)
            {
                characterProjectileSpawner.SetShoot(false);
                characterProjectileSpawner2.SetShoot(true);
                characterProjectileSpawner3.SetShoot(true);

                nbBullet++;
                nbShootBoost++;
            }
            else
            {

                characterProjectileSpawner.SetShootTime(characterProjectileSpawner.GetShootTime()-0.1f);
                characterProjectileSpawner2.SetShootTime(characterProjectileSpawner2.GetShootTime() - 0.1f);
                characterProjectileSpawner3.SetShootTime(characterProjectileSpawner3.GetShootTime() - 0.1f);
                nbShootBoost++;
            }

        } else if (nbBullet == 2 && character.GetShootBoost())
        {
            character.SetShotBoost(false);

            if (nbShootBoost % 3 == 0)
            {
                characterProjectileSpawner.SetShoot(true);
                characterProjectileSpawner2.SetShoot(true);
                characterProjectileSpawner3.SetShoot(true);
                nbShootBoost++;

                nbBullet++;
            }
            else
            {
                characterProjectileSpawner.SetShootTime(characterProjectileSpawner.GetShootTime() - 0.1f);
                characterProjectileSpawner2.SetShootTime(characterProjectileSpawner2.GetShootTime() - 0.1f);
                characterProjectileSpawner3.SetShootTime(characterProjectileSpawner3.GetShootTime() - 0.1f);
                nbShootBoost++;
            }

        }
        else if (character.GetShootBoost())
        {
            character.SetShotBoost(false);

            characterProjectileSpawner.SetShootTime(characterProjectileSpawner.GetShootTime() - 0.1f);
            characterProjectileSpawner2.SetShootTime(characterProjectileSpawner2.GetShootTime() - 0.1f);
            characterProjectileSpawner3.SetShootTime(characterProjectileSpawner3.GetShootTime() - 0.1f);


        }



    }

     
    private void OnEnable()
    {
        
        controls = new PlayerControls();

        controls.Gameplay.Move.performed += ctx => characterMovement.SetMove(ctx.ReadValue<Vector2>());
        controls.Gameplay.Move.canceled += ctx => characterMovement.SetMove(Vector2.zero);

        controls.Gameplay.Aim.performed += ctx => characterAim.SetAim(ctx.ReadValue<Vector2>());
        controls.Gameplay.Aim.canceled += ctx => characterAim.SetAim(Vector2.zero);

        controls.Gameplay.Shoot.performed += ctx => characterProjectileSpawner.Shoot();
        controls.Gameplay.Shoot.performed += ctx => characterProjectileSpawner2.Shoot();
        controls.Gameplay.Shoot.performed += ctx => characterProjectileSpawner3.Shoot();

        controls.Gameplay.Shoot.canceled += ctx => characterProjectileSpawner.UnShoot();
        controls.Gameplay.Shoot.canceled += ctx => characterProjectileSpawner2.UnShoot();
        controls.Gameplay.Shoot.canceled += ctx => characterProjectileSpawner3.UnShoot();

        controls.Gameplay.Boost.performed += ctx => aura.UseBoost();

        controls.Gameplay.Pause.performed += ctx => pauseGame.Pause();

        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

}
