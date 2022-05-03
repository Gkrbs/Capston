# 캡스톤 디자인 음성인식 검투게임

VoiceFighting

### 1. 프로그램 개요
인천대학교 3학년 2학기 졸업작품.

음성인식을 사용한 격투게임이다. 기존 격투게임의 어려운 커맨드를 음성인식을 사용해 간단하게 사용할 수 있게 하여
진입장벽을 낮추기 위해서 제작하였다.

### 1.1 사용 프로그램
유니티 3D(2020.3.25f1)

C#

### 2 프로그램 목표
격투게임을 할 때 복잡한 커맨드가 수십가지가 넘게 존재한다. 신규 유저들은 기존 유저들과 게임을 하기 위해서
복잡한 커맨드를 거의 필수적으로 외워야 한다. 이를 어려워하여 점점 신규 유저들의 유입이 줄어들고
격차가 벌어진다.

이를 완화하기 위해 복잡한 커맨드를 단순한 음성인식으로 구현해내어
신규 유저들의 진입장벽을 낮추고 간단하게 게임을 할 수 있게 하는 것을 목표로 한다.

### 3. 음성인식을 사용한 격투게임

조작키 : 방향키, Z, X, C, V


### 진행상황
2022.3.28

콤보 기능과 점프 기능 추가

애니메이션이 부자연스럽고 점프가 중복입력되는 문제점이 있음

컴퓨터 ai 추가

스크립트 적용 오류로 현재 플레이어를 추적하지 않음 수정필요

마이크로폰 기능추가

버튼을 누르고 음성을 녹음하는 기능
실시간 레코딩 기능으로 전환하여야 함

2022.4.10

시네머신 카메라를 이용한 두 오브젝트를 추적하는 카메라 구현

2022.4.28

메인메뉴 start, option, exit 구현

점프삭제

콤보기능 재구현

zxcv로 공격키 분할

2022.5.01

체력바 구현 -> 데미지 연동 필요

체력이 0이 되면 승리, 패배, 비김 결과 출력

