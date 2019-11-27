using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteSpawnManager : MonoBehaviour
{
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

    public Transform rightPositionLeftTop;
    public Transform rightPositionRightBottom;

    public Transform leftPositionLeftTop;
    public Transform leftPositionRightBottom;

    public Transform leftPositionRightTop;
    public Transform leftPositionLeftBottom;

    public Transform rightPositionLeftBottom;
    public Transform rightPositionRightTop;

    private static InfiniteSpawnManager instance = null;
    public static InfiniteSpawnManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InfiniteSpawnManager>();
            }
            return instance;
        }
    }

    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    private void NormalStageEnemy()
    {
        Character temp;
        Character temp2;
        Character temp3;
        Character temp4;

        Character init;

        int mobNumber = 0;
        if (stage % 100 < 10)
        {
            mobNumber = 0;
        }
        else if (stage % 100 < 20)
        {
            mobNumber = 1;
        }
        else if (stage % 100 < 30)
        {
            mobNumber = 2;
        }
        else if (stage % 100 < 45)
        {
            mobNumber = 3;
        }
        else if (stage % 100 < 60)
        {
            mobNumber = 4;
        }
        else if (stage % 100 < 75)
        {
            mobNumber = 5;
        }
        else if (stage % 100 < 90)
        {
            mobNumber = 6;
        }
        else if (stage % 100 < 100)
        {
            mobNumber = 7;
        }

        switch (mobNumber)
        {
            case 0:
                init = Database.Instance.GetEnemyPrefab(EnemyName.enemy_imp.ToString());
                temp = EnemyPool.Instance.GetFromPool(EnemyName.enemy_imp.ToString());
                temp2 = EnemyPool.Instance.GetFromPool(EnemyName.enemy_imp.ToString());
                temp3 = EnemyPool.Instance.GetFromPool(EnemyName.enemy_imp.ToString());
                temp4 = EnemyPool.Instance.GetFromPool(EnemyName.enemy_imp.ToString());
                break;

            case 1:
                init = Database.Instance.GetEnemyPrefab(EnemyName.enemy_assassin.ToString());
                temp = EnemyPool.Instance.GetFromPool(EnemyName.enemy_assassin.ToString());
                temp2 = EnemyPool.Instance.GetFromPool(EnemyName.enemy_assassin.ToString());
                temp3 = EnemyPool.Instance.GetFromPool(EnemyName.enemy_assassin.ToString());
                temp4 = EnemyPool.Instance.GetFromPool(EnemyName.enemy_assassin.ToString());
                break;

            case 2:
                init = Database.Instance.GetEnemyPrefab(EnemyName.enemy_spearman.ToString());
                temp = EnemyPool.Instance.GetFromPool(EnemyName.enemy_spearman.ToString());
                temp2 = EnemyPool.Instance.GetFromPool(EnemyName.enemy_spearman.ToString());
                temp3 = EnemyPool.Instance.GetFromPool(EnemyName.enemy_spearman.ToString());
                temp4 = EnemyPool.Instance.GetFromPool(EnemyName.enemy_spearman.ToString());
                break;
            case 3:
                init = Database.Instance.GetEnemyPrefab(EnemyName.enemy_vampire.ToString());
                temp = EnemyPool.Instance.GetFromPool(EnemyName.enemy_vampire.ToString());
                temp2 = EnemyPool.Instance.GetFromPool(EnemyName.enemy_vampire.ToString());
                temp3 = EnemyPool.Instance.GetFromPool(EnemyName.enemy_vampire.ToString());
                temp4 = EnemyPool.Instance.GetFromPool(EnemyName.enemy_vampire.ToString());
                break;
            case 4:
                init = Database.Instance.GetEnemyPrefab(EnemyName.enemy_whiteimp.ToString());
                temp = EnemyPool.Instance.GetFromPool(EnemyName.enemy_whiteimp.ToString());
                temp2 = EnemyPool.Instance.GetFromPool(EnemyName.enemy_whiteimp.ToString());
                temp3 = EnemyPool.Instance.GetFromPool(EnemyName.enemy_whiteimp.ToString());
                temp4 = EnemyPool.Instance.GetFromPool(EnemyName.enemy_whiteimp.ToString());
                break;
            case 5:
                init = Database.Instance.GetEnemyPrefab(EnemyName.enemy_blackassassin.ToString());
                temp = EnemyPool.Instance.GetFromPool(EnemyName.enemy_blackassassin.ToString());
                temp2 = EnemyPool.Instance.GetFromPool(EnemyName.enemy_blackassassin.ToString());
                temp3 = EnemyPool.Instance.GetFromPool(EnemyName.enemy_blackassassin.ToString());
                temp4 = EnemyPool.Instance.GetFromPool(EnemyName.enemy_blackassassin.ToString());
                break;
            case 6:
                init = Database.Instance.GetEnemyPrefab(EnemyName.enemy_whitespearman.ToString());
                temp = EnemyPool.Instance.GetFromPool(EnemyName.enemy_whitespearman.ToString());
                temp2 = EnemyPool.Instance.GetFromPool(EnemyName.enemy_whitespearman.ToString());
                temp3 = EnemyPool.Instance.GetFromPool(EnemyName.enemy_whitespearman.ToString());
                temp4 = EnemyPool.Instance.GetFromPool(EnemyName.enemy_whitespearman.ToString());
                break;
            case 7:
            default:
                init = Database.Instance.GetEnemyPrefab(EnemyName.enemy_whitevampire.ToString());
                temp = EnemyPool.Instance.GetFromPool(EnemyName.enemy_whitevampire.ToString());
                temp2 = EnemyPool.Instance.GetFromPool(EnemyName.enemy_whitevampire.ToString());
                temp3 = EnemyPool.Instance.GetFromPool(EnemyName.enemy_whitevampire.ToString());
                temp4 = EnemyPool.Instance.GetFromPool(EnemyName.enemy_whitevampire.ToString());
                break;
        }

        ability(init, temp, rightPositionLeftTop, rightPositionRightBottom);
        ability(init, temp2, leftPositionLeftTop, leftPositionRightBottom);
        ability(init, temp3, leftPositionRightTop, leftPositionLeftBottom);
        ability(init, temp4, rightPositionLeftBottom, rightPositionRightTop);

        currentSpawnCount--;
    }

    
    private void BossStageEnemy()
    {
        Character temp;
        Character init;

        // 그리핀 나올때 나올 사운드이펙트
        //SoundManager.Instance.PlaySFX("boss_spawn");
        init = Database.Instance.GetEnemyPrefab(EnemyName.enemy_griffin.ToString());
        temp = EnemyPool.Instance.GetFromPool(EnemyName.enemy_griffin.ToString());

        switch (Random.Range(0,4))
        {
            case 0:
                bossability(init, temp, rightPositionLeftTop, rightPositionRightBottom);
                break;
            case 1:
                bossability(init, temp, leftPositionLeftTop, leftPositionRightBottom);
                break;
            case 2:
                bossability(init, temp, leftPositionRightTop, leftPositionLeftBottom);
                break;
            case 3:
                bossability(init, temp, rightPositionLeftBottom, rightPositionRightTop);
                break;
        }
    }

    private void LastBossStageEnemy()
    {
        Character temp;
        Character init;

        // 그리핀 나올때 나올 사운드이펙트
        //SoundManager.Instance.PlaySFX("boss_spawn");
        init = Database.Instance.GetEnemyPrefab(EnemyName.enemy_blackgriffin.ToString());
        temp = EnemyPool.Instance.GetFromPool(EnemyName.enemy_blackgriffin.ToString());
        //temp = Instantiate(init).GetComponent<Character>();//

        //EnemyPool.Instance.AddNewEnemy(temp);

        switch (Random.Range(0, 4))
        {
            case 0:
                LastBossability(init, temp, rightPositionLeftTop, rightPositionRightBottom);
                break;
            case 1:
                LastBossability(init, temp, leftPositionLeftTop, leftPositionRightBottom);
                break;
            case 2:
                LastBossability(init, temp, leftPositionRightTop, leftPositionLeftBottom);
                break;
            case 3:
                LastBossability(init, temp, rightPositionLeftBottom, rightPositionRightTop);
                break;
        }
    }

    private IEnumerator spawnEnemy()
    {
        yield return new WaitUntil(() => isLoaded);
        while (true)
        {
            // 일반몬스터
            if (stage % 5 != 0)
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

            // 보스몬스터
            else if (stage % 5 == 0 && stage % 100 != 0)
            {
                if (currentSpawnCount == initSpawnCount)
                {
                    StageEventManager.Instance.BossStageEvent();
                    BossStageEnemy();
                    // 보스스폰마다 자동저장
                    SaveSystemInfinity.Instance.Save();

                    for (float timer = stagegap; timer >= 0; timer -= (Time.deltaTime * GameManager.Instance.GameSpeed))
                    {
                        yield return null;
                    }
                }

                currentmultiple = 0;
                currentSpawnCount = initSpawnCount;
                currentWaveCount = initWaveCount;
            }
            
            // 블랙그리핀 보스
            else if (stage % 100 == 0)
            {
                if (currentSpawnCount == initSpawnCount)
                {
                    StageEventManager.Instance.BossStageEvent();
                    // 라스트보스는 뺀다
                    //LastBossStageEnemy();
                    BossStageEnemy();

                    // 보스스폰마다 자동저장
                    SaveSystemInfinity.Instance.Save();

                    for (float timer = stagegap; timer >= 0; timer -= (Time.deltaTime * GameManager.Instance.GameSpeed))
                    {
                        yield return null;
                    }
                }
            }
            stage++;
            QuestEventManager.Instance.ReceiveEvent(null, QuestEvent.Stage, 1);
        }
    }

    public void LoadStage(int stage, int currentWaveCount, int currentSpawnCount)
    {
        this.stage = stage;
        this.currentWaveCount = currentWaveCount;
        this.currentSpawnCount = currentSpawnCount - 1;
        isLoaded = true;
    }

    private void ability(Character initc, Character tempc, Transform lT, Transform rB)
    {
        tempc.characterInfo.printName = "";
        tempc.characterInfo.damage = Mathf.Floor(Mathf.Pow(initc.characterInfo.damage + stage / 2, 1.0f + (0.005f * (stage - 1))));
        tempc.characterInfo.maxHP = stage * 5 + Mathf.Floor(Mathf.Pow((initc.characterInfo.maxHP + stage * 3f), 1.0f + (0.005f * (stage - 1))));
        tempc.characterInfo.armor = (stage - 1) * 3;
        tempc.characterInfo.gold = (initc.characterInfo.gold + stage / 2) * stage / 2;
        tempc.characterInfo.attackSpeed = initc.characterInfo.attackSpeed;

        tempc.characterInfo.prefix = EnemyPrefixCreator.Instance.RandomEnemyPrefix();
        EnemyPrefixCreator.Instance.SetEnemyPrefix(tempc, tempc.characterInfo.prefix);

        tempc.characterInfo.currentHP = tempc.characterInfo.maxHP;

        float rightrandPosY = Random.Range(rB.position.y, lT.position.y);
        float rightrandPosX = Random.Range(lT.position.x, rB.position.x);
        tempc.transform.position = new Vector3(rightrandPosX, rightrandPosY, 0f);

        tempc.gameObject.SetActive(true);
        EnemyPool.Instance.EnableCharacter(tempc);
    }
    private void bossability(Character initc, Character tempc, Transform lT, Transform rB)
    {
        Transform canvasTransform = tempc.healthBar.transform;

        tempc.transform.localScale = new Vector3(1, 1, 1);
        canvasTransform.transform.localScale = new Vector3(1, 1, 1);

        tempc.transform.position = Vector3.Lerp(lT.position, rB.position, 0.5f);

        tempc.characterInfo.printName = tempc.characterInfo.characterName;
        tempc.characterInfo.damage = Mathf.Floor(Mathf.Pow(initc.characterInfo.damage + (stage - 1), 1.0f + 0.005f * (stage - 1)));
        tempc.characterInfo.maxHP = (stage - 1) * 70 + Mathf.Floor(Mathf.Pow((initc.characterInfo.maxHP + (stage - 1) * 25), 1.0f + 0.005f * (stage - 1)));
        tempc.characterInfo.armor = (stage - 1) * 5;
        tempc.characterInfo.gold = (initc.characterInfo.gold + stage) * stage;

        tempc.characterInfo.currentHP = tempc.characterInfo.maxHP;
        tempc.gameObject.SetActive(true);
        EnemyPool.Instance.EnableCharacter(tempc);
    }
    private void LastBossability(Character initc, Character tempc, Transform lT, Transform rB)
    {
        Transform canvasTransform = tempc.healthBar.transform;

        tempc.transform.localScale = new Vector3(1, 1, 1);
        canvasTransform.transform.localScale = new Vector3(1, 1, 1);

        tempc.transform.position = Vector3.Lerp(lT.position, rB.position, 0.5f);

        tempc.characterInfo.printName = tempc.characterInfo.characterName;
        tempc.characterInfo.damage = initc.characterInfo.damage;
        tempc.characterInfo.maxHP = initc.characterInfo.maxHP;
        tempc.characterInfo.armor = initc.characterInfo.armor;
        tempc.characterInfo.gold = 99999999;

        tempc.characterInfo.currentHP = tempc.characterInfo.maxHP;
        tempc.gameObject.SetActive(true);
        EnemyPool.Instance.EnableCharacter(tempc);
    }
}
