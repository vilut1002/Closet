using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Main_Page : MonoBehaviour
{
    public Image menu_bar, main_bg, menu_bttn, basic_menu, main_bg_dark, cart_page, product_Img;
    public GameObject main_page, search_page, cart_scrollview, category_page, product_page;
    public Image mypage;
    public GameObject pages;
    public GameObject curr_page;
    public GameObject[] cart_elements; //카트 요소들
    public ArrayList cart_content = new ArrayList(); //장바구니에 담긴 상품 리스트
    bool Is_menu_open;
    Animator animator;
    Stack<GameObject> page = new Stack<GameObject>();


    void Start() {
        //Is_menu_open = false;
        menu_bar.gameObject.SetActive(false);
        main_bg.gameObject.SetActive(true);
        menu_bttn.gameObject.SetActive(true);
        main_bg_dark.gameObject.SetActive(false);
        mypage.gameObject.SetActive(false);
        cart_page.gameObject.SetActive(false);
        product_page.gameObject.SetActive(false);
       // get_Image();
        curr_page = main_page;
        main_page.SetActive(true);

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
        main_bg_dark.gameObject.SetActive(false);
       // Is_menu_open = false;
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
    public void go_product_detail()
    {
        product_setting(gameObject.name);
        change_page(product_page);

        
    }

    //상품페이지 세팅
    public void product_setting(string name)
    {
        product_Img.sprite = Resources.Load<Sprite>("1001_prod") ;

    }

    //카테고리 페이지로 이동하기
    public void go_category_page()
    {
        menu_close();
        change_page(category_page);
    }

    //첫메인 화면으로 이동하기
    public void go_main_page()
    {
        change_page(main_page);
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

    

    //장바구니 담기
    public void into_cart()
    {

    }

    //상품 정보 얻기
    public void Get_prod_info()
    {
        
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
