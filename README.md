# 1. 개요
현재 학업 또는 직장에서 일을 하는 사람들한테 가장 중요한 것은 본인이 해야할 일정을 정해두고 확인
하고 
또 일정을 끝냈으면 체크하는 일정 관리 프로그램을 사용하여 업무 생산성을 높이고 일상적인 일정을 
관리하기 위하여도 많이 사용된다. 이러한 일정을 관리할수 있는 TodoList 를 개발하여 사용하는 이들이 일정을 지키는데 도움을 주고자 
개발을 하게되었다. 

# 2. 목표
회원가입 기능 과 로그인 기능 을 넣어 사용자를 식별하고, 식별된 사용자가 일정 리스트를 등록
하고 적어놓은 리스트에 항목을 체크하는 기능 과 삭제 기능을 넣어 일정체크를 도울수 있게 개발해야 한다. 

# 3. 프로젝트 기간
2020년 12월 11일 ~ 2020년 12월13일 (3일)

# 4. 시스템 사양 및 구현 도구
![그림3](https://user-images.githubusercontent.com/57141105/102220681-818ff580-3f24-11eb-9e74-456fd7fc3ee7.png)

# 5. 프로그램 구성
## 5-1. 스키마(Schema)
![그림4](https://user-images.githubusercontent.com/57141105/102220771-9c626a00-3f24-11eb-9050-166896f2ceb1.png)

## 5-2 클래스 다이어그램(Class Diagram)
![그림6](https://user-images.githubusercontent.com/57141105/102220861-b9973880-3f24-11eb-850f-7cb10395f549.png)

## 5-3 시스템 흐름도(System FlowChart)
![그림8](https://user-images.githubusercontent.com/57141105/102220940-d6cc0700-3f24-11eb-80bf-5c1d1be91393.png)

# 6. 프로그램 구동
## 6-1동작과정(Operation Process)
- 로그인 & 회원가입
![그림9-1](https://user-images.githubusercontent.com/57141105/102221207-31656300-3f25-11eb-86a3-7e3e202a17d7.png)
- TodoList 입력
![그림10](https://user-images.githubusercontent.com/57141105/102221209-32969000-3f25-11eb-8fbe-13539e49f302.png)
- TodoList 체크 및 삭제
![그림11](https://user-images.githubusercontent.com/57141105/102221211-332f2680-3f25-11eb-894d-2fe254161788.png)

# 7. 수행결과
## 7-1. 유효성 검사(Validation)
- .Net 정규식을 사용하기 위해 Regex 클래스의 isMatch 메소드를 사용하여 회원가입시 식별 가능한 이메일을 저장할수 있게 검사한다.
![그림12](https://user-images.githubusercontent.com/57141105/102221387-74273b00-3f25-11eb-9c30-2b62b52b53aa.png)

## 7-2. 보안(Security)
- 사용자들에 정보를 수집해야하므로 Password를 SHA-256 해시 알고리즘 함수를 사용하여 데이터를 저장한다.
![그림15png](https://user-images.githubusercontent.com/57141105/102221489-915c0980-3f25-11eb-92a5-8cd4c1503e48.png)

## 7-3. TodoList 입력 및 삭제
![그림14](https://user-images.githubusercontent.com/57141105/102221594-a89af700-3f25-11eb-9fd4-96b96a3392dc.png)
