# SpaceWar
2021년 서울여자대학교 디지털미디어학과 VRARMR프로그래밍 기말 프로젝트<br/>

3D AR 모바일 FPS 게임<br/>
우주를 배경으로 하여 직접 움직이면서 적의 우주선을 해치우는 모바일 FPS AR 게임<br/>
* 본 프로젝트는 서울여자대학교 디지털미디어학과 VRARMR프로그래밍 수업의 기말 프로젝트 결과물입니다.
* 프로젝트 내에 에셋을 사용하였으므로 현재 Repository에는 에셋을 제외한 코드만 존재합니다.
* 본 프로젝트는 Unity 3D와 Vuforia를 처음 다뤄본 프로젝트입니다. Unity 3D의 기본적인 학습을 목표로 한 프로젝트 입니다.

## 게임 소개
'SpaceWar'은 FPS 게임에 AR 요소를 추가하여 실제로 플레이어가 움직이면서 적을 조준해 공격하는 모바일 FPS AR 게임입니다.<br>
 플레이어가 현재의 환경에서 실제로 적과 행성이 있는 것 같은 느낌을 주는 것을 목적으로 하고 있습니다. <br/>

### 게임 특징
* 직접 움직이면서 적을 조준하는 게임 방식
  * 직접 몸을 움직이면서 휴대폰 안의 적을 조준함으로써 게임 속으로 들어가 실제로 전투를 하는 것 같은 느낌을 제공합니다.
  <br/><img width="50%" src="https://user-images.githubusercontent.com/68226341/223625763-ad0928e6-4803-4c9b-a4ab-50e00f0e6025.png"/><img width="50%" src="https://user-images.githubusercontent.com/68226341/223626692-ec060b7e-594b-4132-9097-ac5413641a6a.png"/>
* 현실 공간과 어우러진 배경
  * 카메라를 사용하여 현실 배경과 어우러진 행성, 별을 감상할 수 있습니다.
  <br/><img width="50%" src="https://github.com/user-attachments/assets/4210d348-b21d-44c7-ab2f-a90314e18979"/><img width="50%" src="https://github.com/user-attachments/assets/b98278c1-c7b1-4f89-8854-45f9de6d2dc3"/>
## 프로젝트 개요
### 개발 기간
* 2021.11 - 2021.12 (약 1개월)
### 개발 환경
* Unity 2020.1.17
* Vuforia
### 수행업무
개인 프로젝트입니다.
* 씬 구성 및 씬 이동 제작
  * LoadScene(), LoadSceneMode.Additive를 활용한 씬 이동 제작
  * 플레이어에 대한 씬과 게임 스테이지 씬 분리
* 스테이지 제작
  * 난이도에 따른 스테이지 4개 제작
  * 스테이지에 따른 게임 난이도 설정
* 플레이어 관리 및 제작
  * 충돌처리를 통한 플레이어 피격, 사망처리 제작
  * Raycast를 사용해 플레이어 공격, 아이템 획득 제작
* 적 스폰 및 공격, 사망 제작
  * Prefab과 Instantiate()을 사용한 적 생성 및 적 미사일 공격 생성
  * Random.Range()를 활용한 랜덤 적, 랜덤 위치 생성
  * Transform.LookAt()을 활용한 적 공격 조준
  * InvokeRepeating()을 활용한 주기적 적 공격 제작
* 아이템 스폰 및 적용 제작
  * Prefab과 Instantiate()을 사용한 아이템 생성
  * Random.Range()를 활용한 랜덤 아이템, 랜덤 위치 생성
* 튜토리얼 및 게임 UI 제작
  * UI 제작 및 연결
* 게임 사운드 적용
  * AudioSource를 활용한 게임 사운드 적용
* BillBoard 제작
  * 오브젝트가 카메라의 위치를 바라보도록 BillBoard 제작
## 프로젝트 성과
* 서울여자대학교 VRARMR프로그래밍 수업 기말 프로젝트 성적 만점
