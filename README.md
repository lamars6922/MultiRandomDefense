# MultiRandomDefense (용병랜덤디팬스)
------------
![용병랜덤디펜스 메인](https://user-images.githubusercontent.com/57030114/69808264-7b9c7900-122a-11ea-8847-257462469616.PNG)
![게임플레이](https://user-images.githubusercontent.com/57030114/69808288-82c38700-122a-11ea-8265-04cdec001f5f.PNG)
![게임플레이2](https://user-images.githubusercontent.com/57030114/69808282-80f9c380-122a-11ea-8783-525ffeb9fc4c.jpg)
* 교내 창업동아리의 활동으로 게임을 제작하여 Google PlayStore에 출시한 게임입니다. 기본적인 게임 내용은 랜덤으로 유닛을 뽑아서 몰려오는 적으로부터 거점을 지키는 게임으로 100라운드까지있는 일반모드와 무한모드 그리고 유닛들의 능력치를 올려주는 상점이 있습니다.
------------

# 팀 프로젝트
* 제작 인원 : 5명

# 개요
* 게임 명 : 용병 랜덤 디펜스
* 개발 툴 : Unity, Visual Studio 2017
* 개발 언어 : C#
* 플랫폼 : Android

# 제작 기간
* 2018.11 ~ 2019.04
* 2019.04 (출시)
* 2019.07 (무한모드, 상점, 밸런스 업데이트)

# 맡은 역할
* 일반 모드 스테이지 구성
* 무한 모드 스테이지 구성
* 오브젝트 풀 (유닛, 몬스터, 텍스트 이펙트, 버프)
* 레벨 디자인
* 토템 시스템 구현
* 테스트
-------------
# 상세내용
![NormalStage](https://user-images.githubusercontent.com/57030114/69809432-16965280-122d-11ea-87bd-8c64f2b20e79.PNG)
* 총 100 라운드로 구성되어 있고, 각 라운드에 비례하여 점점 강한 적군들이 출현합니다.
* 5 라운드마다 보스 몬스터가 출현합니다.
* 적군들은 가장 오른쪽에서 나타나며, 왼쪽으로 이동합니다.
* 아군은 화면에서 비치는 모든 곳에 배치가 가능합니다.
* 몬스터 스폰은 코루틴을 이용하여 구현했습니다.
* 몬스터는 오프젝트 풀에 저장되어 있어 스폰이 될 때 해당 라운드에 알맞게 능력치가 조정되서 나옵니다.

![infiniteStage](https://user-images.githubusercontent.com/57030114/69809437-18601600-122d-11ea-8845-eb150954962a.PNG)
* 무한 라운드로 구성되어 있고, 각 라운드에 비례하여 점점 강한 적군들이 출현합니다.
* 몬스터는 중앙을 기준으로 오른쪽 위, 왼쪽 위, 오른쪽 아래, 왼쪽 아래에서 적군들이 출현합니다.
* 아군은 화면에서 비치는 모든 곳에 배치가 가능합니다.
* 몬스터 스폰은 코루틴을 이용하여 구현했습니다.
* 몬스터는 오프젝트 풀에 저장되어 있어 스폰이 될 때 해당 라운드에 알맞게 능력치가 조정되서 나옵니다.

![buffststem](https://user-images.githubusercontent.com/57030114/69810144-940e9280-122e-11ea-8a0d-98b3cbfeb88a.PNG)![buffsystem2](https://user-images.githubusercontent.com/57030114/69810150-9b35a080-122e-11ea-8368-ea75e0f1d9a0.PNG)

* 토템UI을 구현했습니다. 토템에 능력은 힐, 공격력 버프, 방어력 버프, 지속 데미지, 이속 감소 능력을 가지고있습니다.
* 토템은 drug&drop를 이용하여 소환할 수 있습니다. (drugAndDrop handler 사용)
* 토템은 다시 사용하기 위해서는 일정한 시간이 지나야하고 그것을 구현하기위해 코루틴을 이용했습니다.
* 토템 범위에 있는 유닛들은 유닛 오브젝트에 있는 BuffSystem에 의해 효과가 발휘 됩니다.
* 토템의 정보를 보여주는 UI 함수 구현
