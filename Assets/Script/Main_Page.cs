using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Main_Page : MonoBehaviour
{
    public Image menu_bar, main_bg, menu_bttn, basic_menu, main_bg_dark, cart_page, product_Img, mysize, order_page;
    public GameObject main_page, search_page, cart_scrollview, category_page_f, category_page_m,  page_1001, page_2001, page_4001, page_4002;
    public Image mypage;
    public GameObject pages;
    public GameObject curr_page, survey, survey_bttn1, survey_bttn2, survey_end;
    public GameObject[] cart_elements; //카트 요소들
    public ArrayList cart_content = new ArrayList(); //장바구니에 담긴 상품 리스트
    public Text a;
    public InputField d;
    public Dropdown cate1, cate2;
    bool Is_menu_open, gender, Is_survey;
    Animator animator;
    Stack<GameObject> page = new Stack<GameObject>();
    Dropdown.OptionData option0, option1, option2, option3, option4, option5;
    
    void Start() {
        //Is_menu_open = false;
        menu_bar.gameObject.SetActive(false);
        basic_menu.gameObject.SetActive(true);
        main_bg.gameObject.SetActive(true);
        menu_bttn.gameObject.SetActive(true);
        main_bg_dark.gameObject.SetActive(false);
        mypage.gameObject.SetActive(false);
        cart_page.gameObject.SetActive(false);
        page_1001.gameObject.SetActive(false);
        page_2001.gameObject.SetActive(false);
        page_4001.gameObject.SetActive(false);
        page_4002.gameObject.SetActive(false);
        // get_Image();
        curr_page = main_page;
        main_page.SetActive(true);
        mysize.gameObject.SetActive(false);
        order_page.gameObject.SetActive(false);
        survey.SetActive(false);
        survey_end.SetActive(false);
        cate1.options.Clear();
        cate2.options.Clear();

    }

    //왼쪽 메뉴바 열기

    public void menu_open()
    {

        animator = menu_bar.GetComponent<Animator>();
        Is_menu_open = animator.GetBool("Is_menu_open");

        animator.SetBool("Is_menu_open", !Is_menu_open);
            menu_bar.gameObject.SetActive(true);
            //main_bg_dark.gameObject.SetActive(true);
            //Is_menu_open = true;
        
    }

    //왼쪽 메뉴바 닫기
    public void menu_close()
    {
        animator.SetBool("Is_menu_open", false);
        main_bg_dark.gameObject.SetActive(false);
       // Is_menu_open = false;
    }

    //내 사이즈 뒤로가기
    public void mysize_back()
    {
        change_page(mypage.gameObject);
    }

    //마이페이지 버튼 눌렀을 때
    public void my_page()
    {

        change_page(mypage.gameObject);

    }

    //뒤로가기 버튼 눌렀을때 이전 화면으로 바꾸기
    public void back_prev_page()
    {
   
        change_page(page.Pop());
    }

    //상품 페이지로 이동하기
    public void go_product_1001()
    {
        change_page(page_1001);
        
    }
    public void go_product_2001()
    {
        change_page(page_2001);

    }
    public void go_product_4001()
    {
        change_page(page_4001);

    }
    public void go_product_4002()
    {
        change_page(page_4002);

    }

    //내 사이즈 페이지로 이동하기
    public void go_mysize()
    {
        change_page(mysize.gameObject);
    }

    //카테고리 페이지로 이동하기
    public void go_categoryf_page()
    {
        gender = true;
        cate1_setting_f();
        change_page(category_page_f);
    }
    public void go_categorym_page()
    {
        gender = false;
        cate1_setting_m();
        change_page(category_page_m);
    }

    //첫메인 화면으로 이동하기
    public void go_main_page()
    {
        change_page(main_page);
    }

    //배송조회 및 주문확인 페이지로 이동하기
    public void go_order_page()
    {
        change_page(order_page.gameObject);
        survey.SetActive(false);
        survey_end.SetActive(false);
    }


    //검색페이지로 이동하기
    public void go_search_page()
    {
        change_page(search_page);
    }

    //화면 전환
    public void change_page(GameObject new_page)
    {
        curr_page.SetActive(false);
        new_page.SetActive(true);
        curr_page = new_page;
        page.Push(curr_page);
        menu_close();
    }

    //장바구니 화면으로 가기
    public void go_cart()
    {
        change_page(cart_page.gameObject);
        /*cart_scrollview.GetComponent<RectTransform>().sizeDelta = new Vector2(500, cart_content.Count*200);
        IEnumerator cart_list = cart_content.GetEnumerator();
        int i = 0;
        while (cart_list.MoveNext())
        {
            cart_elements[i] = (GameObject)cart_list.Current;
        }
        */
    }

    //여성 카테고리1 세팅
    public void cate1_setting_f()
    {
        
        cate1.ClearOptions();
        cate2.ClearOptions();
        Debug.Log(cate1.options);
        List<Dropdown.OptionData> messages1 = new List<Dropdown.OptionData>();
        option0 = new Dropdown.OptionData();
        option0.text = "상의";
        messages1.Add(option0);

        option1 = new Dropdown.OptionData();
        option1.text = "하의";
        messages1.Add(option1);

        option2 = new Dropdown.OptionData();
        option2.text = "아우터";
        messages1.Add(option2);

        option3 = new Dropdown.OptionData();
        option3.text = "드레스";
        messages1.Add(option3);

        option4 = new Dropdown.OptionData();
        option4.text = "Others";
        messages1.Add(option4);

        cate1.AddOptions(messages1);
        //cate2 옵션 설정
        List<Dropdown.OptionData> messages2 = new List<Dropdown.OptionData>();
        option0 = new Dropdown.OptionData();
        option0.text = "티셔츠";
        messages2.Add(option0);

        option1 = new Dropdown.OptionData();
        option1.text = "니트/가디건";
        messages2.Add(option1);

        option2 = new Dropdown.OptionData();
        option2.text = "블라우스/셔츠";
        messages2.Add(option2);

        option3 = new Dropdown.OptionData();
        option3.text = "후드/맨투맨";
        messages2.Add(option3);


        cate2.AddOptions(messages2);

    }

    //여성 카테고리2 세팅
    public void cate2_setting_f()
    {
        cate2.ClearOptions();
        List<Dropdown.OptionData> messages2 = new List<Dropdown.OptionData>();
        switch (cate1.value)
        {

            case 0:
                option0 = new Dropdown.OptionData();
                option0.text = "티셔츠";
                messages2.Add(option0);

                option1 = new Dropdown.OptionData();
                option1.text = "니트/가디건";
                messages2.Add(option1);

                option2 = new Dropdown.OptionData();
                option2.text = "블라우스/셔츠";
                messages2.Add(option2);

                option3 = new Dropdown.OptionData();
                option3.text = "후드/맨투맨";
                messages2.Add(option3);
                
                cate2.AddOptions(messages2);
                break;

            case 1:
                option0 = new Dropdown.OptionData();
                option0.text = "청바지";
                messages2.Add(option0);

                option1 = new Dropdown.OptionData();
                option1.text = "트레이닝바지";
                messages2.Add(option1);

                option2 = new Dropdown.OptionData();
                option2.text = "면/슬랙스";
                messages2.Add(option2);

                option3 = new Dropdown.OptionData();
                option3.text = "반바지";
                messages2.Add(option3);

                option4 = new Dropdown.OptionData();
                option4.text = "스커트";
                messages2.Add(option4);

                cate2.AddOptions(messages2);
                break;

            case 2:
                option0 = new Dropdown.OptionData();
                option0.text = "미니원피스";
                messages2.Add(option0);

                option1 = new Dropdown.OptionData();
                option1.text = "롱원피스";
                messages2.Add(option1);

                option2 = new Dropdown.OptionData();
                option2.text = "오버롤";
                messages2.Add(option2);

                cate2.AddOptions(messages2);
      
                break;

            case 3:
                option0 = new Dropdown.OptionData();
                option0.text = "자켓";
                messages2.Add(option0);

                option1 = new Dropdown.OptionData();
                option1.text = "코트";
                messages2.Add(option1);

                option2 = new Dropdown.OptionData();
                option2.text = "후드집업";
                messages2.Add(option2);

                option3 = new Dropdown.OptionData();
                option3.text = "바람막이";
                messages2.Add(option3);

                option4 = new Dropdown.OptionData();
                option4.text = "패딩";
                messages2.Add(option4);

                cate2.AddOptions(messages2);
                break;
            case 4:
                option0 = new Dropdown.OptionData();
                option0.text = "가방";
                messages2.Add(option0);

                option1 = new Dropdown.OptionData();
                option1.text = "신발";
                messages2.Add(option1);

                option2 = new Dropdown.OptionData();
                option2.text = "양말";
                messages2.Add(option2);

                option3 = new Dropdown.OptionData();
                option3.text = "모자";
                messages2.Add(option3);

                option4 = new Dropdown.OptionData();
                option4.text = "악세서리";
                messages2.Add(option4);

                cate2.AddOptions(messages2);
                break;
        }
    }

    //카테고리 성별 선택
    public void cate2_gender()
    {
        if (gender)
        {
            cate2_setting_f();
        }
        else
        {
            cate2_setting_m();
        }
    }

    //남성 카테고리1 세팅
    public void cate1_setting_m()
    {

        cate1.ClearOptions();
        cate2.ClearOptions();
        Debug.Log(cate1.options);
        List<Dropdown.OptionData> messages1 = new List<Dropdown.OptionData>();
        option0 = new Dropdown.OptionData();
        option0.text = "상의";
        messages1.Add(option0);

        option1 = new Dropdown.OptionData();
        option1.text = "하의";
        messages1.Add(option1);

        option2 = new Dropdown.OptionData();
        option2.text = "아우터";
        messages1.Add(option2);

        option3 = new Dropdown.OptionData();
        option3.text = "Others";
        messages1.Add(option3);
        

        cate1.AddOptions(messages1);
        //cate2 옵션 설정
        List<Dropdown.OptionData> messages2 = new List<Dropdown.OptionData>();
        option0 = new Dropdown.OptionData();
        option0.text = "티셔츠";
        messages2.Add(option0);

        option1 = new Dropdown.OptionData();
        option1.text = "니트/가디건";
        messages2.Add(option1);

        option2 = new Dropdown.OptionData();
        option2.text = "블라우스/셔츠";
        messages2.Add(option2);

        option3 = new Dropdown.OptionData();
        option3.text = "후드/맨투맨";
        messages2.Add(option3);


        cate2.AddOptions(messages2);

    }

    //남성 카테고리2 세팅
    public void cate2_setting_m()
    {
        cate2.ClearOptions();
        List<Dropdown.OptionData> messages2 = new List<Dropdown.OptionData>();
        switch (cate1.value)
        {

            case 0:
                option0 = new Dropdown.OptionData();
                option0.text = "티셔츠";
                messages2.Add(option0);

                option1 = new Dropdown.OptionData();
                option1.text = "니트/가디건";
                messages2.Add(option1);

                option2 = new Dropdown.OptionData();
                option2.text = "셔츠";
                messages2.Add(option2);

                option3 = new Dropdown.OptionData();
                option3.text = "후드/맨투맨";
                messages2.Add(option3);

                cate2.AddOptions(messages2);
                break;

            case 1:
                option0 = new Dropdown.OptionData();
                option0.text = "청바지";
                messages2.Add(option0);

                option1 = new Dropdown.OptionData();
                option1.text = "트레이닝바지";
                messages2.Add(option1);

                option2 = new Dropdown.OptionData();
                option2.text = "면/슬랙스";
                messages2.Add(option2);

                option3 = new Dropdown.OptionData();
                option3.text = "반바지";
                messages2.Add(option3);
                

                cate2.AddOptions(messages2);
                break;
                

            case 2:
                option0 = new Dropdown.OptionData();
                option0.text = "자켓";
                messages2.Add(option0);

                option1 = new Dropdown.OptionData();
                option1.text = "코트";
                messages2.Add(option1);

                option2 = new Dropdown.OptionData();
                option2.text = "후드집업";
                messages2.Add(option2);

                option3 = new Dropdown.OptionData();
                option3.text = "바람막이";
                messages2.Add(option3);

                option4 = new Dropdown.OptionData();
                option4.text = "패딩";
                messages2.Add(option4);

                cate2.AddOptions(messages2);
                break;

            case 3:
                option0 = new Dropdown.OptionData();
                option0.text = "가방";
                messages2.Add(option0);

                option1 = new Dropdown.OptionData();
                option1.text = "신발";
                messages2.Add(option1);

                option2 = new Dropdown.OptionData();
                option2.text = "양말";
                messages2.Add(option2);

                option3 = new Dropdown.OptionData();
                option3.text = "모자";
                messages2.Add(option3);

                option4 = new Dropdown.OptionData();
                option4.text = "악세서리";
                messages2.Add(option4);

                cate2.AddOptions(messages2);
                break;
        }
    }

    //설문 참여하기 버튼
    public void survey_on()
    {
        if (!Is_survey)
        {
            survey.SetActive(true);
            main_bg_dark.gameObject.SetActive(true);
            survey_bttn1.GetComponent<Button>().interactable= false;
            survey_bttn2.GetComponent<Button>().interactable = false;
            Is_survey = !Is_survey;
        }
        else
        {
            survey.SetActive(false);
            main_bg_dark.gameObject.SetActive(false);
            survey_bttn1.GetComponent<Button>().interactable = true;
            survey_bttn2.GetComponent<Button>().interactable = true;
            Is_survey = !Is_survey;
        }
    }

    //적립하기 버튼
    public void point()
    {
        survey.SetActive(false);
        survey_end.SetActive(true);

    }

    public void OK()
    {
        survey_end.SetActive(false);
    }

    


    /*
    public string url = "https://community.arm.com/cfs-file/__key/communityserver-blogs-components-weblogfiles/00-00-00-20-66/6180.mali_2D00_shield_2D00_2.png";

    public void get_Image() {
        GetTexture();
    }

    IEnumerator GetTexture()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            product.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        }
    }
    */





}
