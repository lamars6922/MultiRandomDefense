using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField]
    private EnemyPool enemyP;
    [SerializeField]
    public int currentWaveCount;
    [SerializeField]
    public int currentSpawnCount;
    [SerializeField]
    public int currentmultiple;

    public bool isLoaded = false;

    public int stage = 1;
    public int initWaveCount;
    public int initSpawnCount;
    public int initmultiple;

    public float spawngap;
    public float wavegap;
    public float stagegap;

    public Transform spawnPositionLeftTop;
    public Transform spawnPositionRightBottom;


    private static EnemySpawnManager instance = null;
    public static EnemySpawnManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EnemySpawnManager>();
            }
            return instance;
        }
    }

    void Start()
    {
        //LoadStage(1, initWaveCount, initSpawnCount);
        StartCoroutine(spawnEnemy());
    }

    private void NormalStageEnemy()
    {
        Character temp;
        Character init;

        int mobNumber = 0;
        if(stage < 10)
        {
            mobNumber = 0;
        }
        else if(stage < 20)
        {
            mobNumber = 1;
        }
        else if(stage < 30)
        {
            mobNumber = 2;
        }
        else if(stage < 45)
        {
            mobNumber = 3;
        }
        else if (stage < 60)
        {
            mobNumber = 4;
        }
        else if (stage < 75)
        {
            mobNumber = 5;
        }
        else if (stage < 90)
        {
            mobNumber = 6;
        }
        else if (stage < 100)
        {
            mobNumber = 7;
        }

        switch (mobNumber)
        {
            case 0:
                init = Database.Instance.GetEnemyPrefab(EnemyName.enemy_imp.ToString());
                temp = EnemyPool.Instance.GetFromPool(EnemyName.enemy_imp.ToString());
                break;
                
            case 1:
                init = Database.Instance.GetEnemyPrefab(EnemyName.enemy_assassin.ToString());
                temp = EnemyPool.Instance.GetFromPool(EnemyName.enemy_assassin.ToString());
                break;

            case 2:
                init = Database.Instance.GetEnemyPrefab(EnemyName.enemy_spearman.ToString());
                temp = EnemyPool.Instance.GetFromPool(EnemyName.enemy_spearman.ToString());
                break;
            case 3:
                init = Database.Instance.GetEnemyPrefab(EnemyName.enemy_vampire.ToString());
                temp = EnemyPool.Instance.GetFromPool(EnemyName.enemy_vampire.ToString());
                break;
            case 4:
                init = Database.Instance.GetEnemyPrefab(EnemyName.enemy_whiteimp.ToString());
                temp = EnemyPool.Instance.GetFromPool(EnemyName.enemy_whiteimp.ToString());
                break;
            case 5:
                init = Database.Instance.GetEnemyPrefab(EnemyName.enemy_blackassassin.ToString());
                temp = EnemyPool.Instance.GetFromPool(EnemyName.enemy_blackassassin.ToString());
                break;
            case 6:
                init = Database.Instance.GetEnemyPrefab(EnemyName.enemy_whitespearman.ToString());
                temp = EnemyPool.Instance.GetFromPool(EnemyName.enemy_whitespearman.ToString());
                break;
            case 7:
            default:
                init = Database.Instance.GetEnemyPrefab(EnemyName.enemy_whitevampire.ToString());
                temp = EnemyPool.Instance.GetFromPool(EnemyName.enemy_whitevampire.ToString());
                break;
        }

        temp.characterInfo.printName = "";
        temp.characterInfo.damage = Mathf.Floor(Mathf.Pow(init.characterInfo.damage + stage/2, 1.0f + 0.01f * (stage - 1)));
        temp.characterInfo.maxHP = stage*5 + Mathf.Floor(Mathf.Pow((init.characterInfo.maxHP + stage*3f), 1.0f + 0.01f * (stage - 1)));
        temp.characterInfo.armor = (stage - 1) * 3;
        temp.characterInfo.gold = (init.characterInfo.gold + stage/2) * stage/2;
        temp.characterInfo.attackSpeed = init.characterInfo.attackSpeed;

        temp.characterInfo.prefix = EnemyPrefixCreator.Instance.RandomEnemyPrefix();
        EnemyPrefixCreator.Instance.SetEnemyPrefix(temp, temp.characterInfo.prefix);

        temp.characterInfo.currentHP = temp.characterInfo.maxHP;

        float randPosY = Random.Range(spawnPositionRightBottom.position.y, spawnPositionLeftTop.position.y);
        float randPosX = Random.Range(spawnPositionLeftTop.position.x, spawnPositionRightBottom.position.x);
        temp.transform.position = new Vector3(randPosX, randPosY, 0f);

        temp.gameObject.SetActive(true);
        EnemyPool.Instance.EnableCharacter(temp);

        currentSpawnCount--;
    }

    private void BossStageEnemy()
    {
        Character temp;
        Character init;

        // 그리핀 나올때 나올 사운드이펙트
        //SoundManager.Instance.PlaySFX("boss_spawn");
        init = Database.Instance.GetEnemyPrefab(EnemyName.enemy_griffin.ToString());
        temp = enemyP.GetFromPool(EnemyName.enemy_griffin.ToString());

        Transform canvasTransform = temp.healthBar.transform;

        temp.transform.localScale = new Vector3(1, 1, 1);
        canvasTransform.transform.localScale = new Vector3(1, 1, 1);

        temp.transform.position = Vector3.Lerp(spawnPositionLeftTop.position, spawnPositionRightBottom.position, 0.5f);

        temp.characterInfo.printName = temp.characterInfo.characterName;
        temp.characterInfo.damage = Mathf.Floor(Mathf.Pow(init.characterInfo.damage + (stage - 1), 1.0f + 0.01f * (stage - 1)));
        temp.characterInfo.maxHP = (stage - 1) * 70 + Mathf.Floor(Mathf.Pow((init.characterInfo.maxHP + (stage - 1) * 25), 1.0f + 0.01f * (stage - 1)));
        temp.characterInfo.armor = (stage - 1) * 5;
        temp.characterInfo.gold = (init.characterInfo.gold + stage) * stage;

        temp.characterInfo.currentHP = temp.characterInfo.maxHP;
        temp.gameObject.SetActive(true);
        EnemyPool.Instance.EnableCharacter(temp);
    }

    private void LastBossStageEnemy()
    {
        Character temp;
        Character init;

        // 그리핀 나올때 나올 사운드이펙트
        //SoundManager.Instance.PlaySFX("boss_spawn");
        init = Database.Instance.GetEnemyPrefab(EnemyName.enemy_blackgriffin.ToString());
        temp = Instantiate(init).GetComponent<Character>();//enemyP.GetFromPool(EnemyName.enemy_blackgriffin.ToString());
        EnemyPool.Instance.AddNewEnemy(temp);

        Transform canvasTransform = temp.healthBar.transform;

        temp.transform.localScale = new Vector3(1, 1, 1);
        canvasTransform.transform.localScale = new Vector3(1, 1, 1);

        temp.transform.position = Vector3.Lerp(spawnPositionLeftTop.position, spawnPositionRightBottom.position, 0.5f);

        temp.characterInfo.printName = temp.characterInfo.characterName;
        temp.characterInfo.damage = init.characterInfo.damage;
        temp.characterInfo.maxHP = init.characterInfo.maxHP;
        temp.characterInfo.armor = init.characterInfo.armor;
        temp.characterInfo.gold = 99999999;

        temp.characterInfo.currentHP = temp.characterInfo.maxHP;
        temp.gameObject.SetActive(true);
        EnemyPool.Instance.EnableCharacter(temp);
    }

    private IEnumerator spawnEnemy()
    {
        //return new WaitUntil(() => isLoaded);
        while (true)
        {
            // 100스테이지에서 무한루프 빠지는거 임시방편용
            if (stage >= 100)
            {
                StageEventManager.Instance.BossStageEvent();
                LastBossStageEnemy();
                break;
            }

            if (stage % 5 != 0 && stage <= 100)
            {
                StageEventManager.Instance.NormalStageEvent();

                while (currentWaveCount > 0)
                {
                    if (currentSpawnCount > 0)
                    {
                        for (float timer = spawngap; timer >= 0; timer -= (Time.deltaTime * GameManager.Instance.GameSpeed))
                        {
                            yield return null;
                        }
                        NormalStageEnemy();
                    }
                    else
                    {
                        currentmultiple += initmultiple;
                        currentSpawnCount = initSpawnCount + currentmultiple;
                        currentWaveCount--;

                        for (float timer = wavegap; timer >= 0; timer -= (Time.deltaTime * GameManager.Instance.GameSpeed))
                        {
                            yield return null;
                        }
                    }
                }

                for (float timer = stagegap; timer >= 0; timer -= (Time.deltaTime * GameManager.Instance.GameSpeed))
                {
                    yield return null;
                }
                currentmultiple = 0;
                currentSpawnCount = initSpawnCount;
                currentWaveCount = initWaveCount;
            }
            else if (stage % 5 == 0 && stage <= 100)
            {
                if(currentSpawnCount == initSpawnCount)
                {
                    StageEventManager.Instance.BossStageEvent();
                    BossStageEnemy();
                    // 보스스폰마다 자동저장
                    SaveSystem.Instance.Save();

                    for (float timer = stagegap; timer >= 0; timer -= (Time.deltaTime * GameManager.Instance.GameSpeed))
                    {
                        yield return null;
                    }
                }
                
                currentmultiple = 0;
                currentSpawnCount = initSpawnCount;
                currentWaveCount = initWaveCount;
            }
            stage++;
            QuestEventManager.Instance.ReceiveEvent(null, QuestEvent.Stage, 1);
        }
    }

    public void LoadStage(int stage, int currentWaveCount, int currentSpawnCount)
    {
        this.stage = stage;
        this.currentWaveCount = currentWaveCount;
        this.currentSpawnCount = currentSpawnCount-1;
        isLoaded = true;
    }

}