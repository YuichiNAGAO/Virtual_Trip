using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class AllManger : MonoBehaviour
{
    public GameObject compasstext;
    public GameObject compassroot;
    public GameObject cityname;
    public GameObject citydescription;
    public GameObject cityimage;
    public GameObject targetcanvas;
    public GameObject restartbutton;
    public GameObject canvastripdescription;
    public GameObject canvasar;

    public GameObject log;


    public Dictionary<string,Location> location_dict = new Dictionary<string,Location>();
    public Dictionary<string,string> description_dict = new Dictionary<string,string>();

    
    
    // Start is called before the first frame update
    void Start()
    {
        canvasar.SetActive(true);
        canvastripdescription.SetActive(false);
        targetcanvas.SetActive(true);
        Input.compass.enabled = true;
		Input.location.Start();
        makecitylocation();
        makecitydescription();
    }

    // Update is called once per frame
    void Update()
    {
        // オブジェクトからTextコンポーネントを取得
        Text score_text = compasstext.GetComponent<Text> ();
        // テキストの表示を入れ替える
        score_text.text = ((int)Input.compass.trueHeading).ToString() + "°";
        compassroot.transform.rotation=Quaternion.Euler(0, 0, Input.compass.trueHeading);

    }
    public void Restart(){
        canvasar.SetActive(true);
        targetcanvas.SetActive(true);
        canvastripdescription.SetActive(false);

    }

    public void GoToDestination(){
        Text log_text = log.GetComponent<Text> ();
        Image image_component = cityimage.GetComponent<Image>();
        string log_string=string.Empty;
        // Location shibuya = new Location(35.658126d, 139.701616d);
        // Location hakata = new Location(33.590322d, 130.420675d);
        float devicedirection=Input.compass.trueHeading;
        LocationInfo locationInfo = Input.location.lastData;
        Location deviceLocation = new Location(locationInfo.latitude, locationInfo.longitude);
        Text cityname_text = cityname.GetComponent<Text> ();
        Text citydescription_text = citydescription.GetComponent<Text> ();
        Location tmp_location;
        float tmp_direction_diff=360;
        string dest=string.Empty;

        Dictionary<string,double>  direction_dict = new Dictionary<string,double>();
        
        foreach (string key in location_dict.Keys)
        {
            tmp_location=location_dict[key];

            // cityname.text =NaviMath.LatlngDirection(deviceLocation,tmp_location).ToString();
            direction_dict.Add(key,NaviMath.LatlngDirection(deviceLocation,tmp_location));
        }
        log_string+=devicedirection.ToString()+"\n";
        foreach (string key in direction_dict.Keys)
        {
            
            log_string+=key+":";
            log_string+=direction_dict[key].ToString()+":";
            float abs_diff=Math.Abs(devicedirection-(float)direction_dict[key]);
            float min_direction_diff=Math.Min(abs_diff,360-abs_diff);
            log_string+=min_direction_diff.ToString()+"\n";
            if (tmp_direction_diff>=min_direction_diff){
                tmp_direction_diff=min_direction_diff;
                dest=key;
                
            }
            
        }
        cityname_text.text =dest;
        citydescription_text.text=description_dict[dest];
        // cityname.text=devicedirection.ToString();
        // targetcanvas.SetActive(false);
        log_text.text=log_string;

        Texture2D texture = Resources.Load(dest) as Texture2D;
        image_component.sprite = Sprite.Create(texture,
                                       new Rect(0, 0, texture.width, texture.height),
                                       Vector2.zero);


        canvasar.SetActive(false);
        targetcanvas.SetActive(false);
        canvastripdescription.SetActive(true);
    }

    void makecitylocation(){
        Location Cairo = new Location(30.064742d, 31.249509d);
        Location Sydney = new Location(-33.891576d, 151.241709d);
        Location Shanghai = new Location(31.247869d, 121.472702d);
        Location Singapore = new Location(1.298828d, 103.824898d);
        Location Seoul = new Location(37.532308d, 126.95744d);
        Location Paris = new Location(48.85284d, 2.349857d);
        Location Milano = new Location(45.471156d, 9.185727d);
        Location Moscow = new Location(55.746455d, 37.631895d);
        Location Rio = new Location(-22.90937d, -43.214998d);
        Location NewYork = new Location(40.71417d, -74.00639d);
        Location Oakland = new Location(-36.904148d, 174.760498d);
        Location Mexico = new Location(19.410636d, -99.130588d);
        Location Ottawa = new Location(45.411572d, -75.698194d);
        Location London = new Location(51.508967d, -0.126127d);
        
        location_dict.Add("Cairo", Cairo);
        location_dict.Add("Sydney", Sydney);
        location_dict.Add("Shanghai", Shanghai);
        location_dict.Add("Singapore", Singapore);
        location_dict.Add("Seoul", Seoul);
        location_dict.Add("Paris", Paris);
        location_dict.Add("Milano", Milano);
        location_dict.Add("Moscow", Moscow);
        location_dict.Add("Rio de Janeiro", Rio);
        location_dict.Add("New York", NewYork);
        location_dict.Add("Oakland", Oakland);
        location_dict.Add("Mexico City", Mexico);
        location_dict.Add("Ottawa", Ottawa);
        location_dict.Add("London", London);
    }

    void makecitydescription(){
        description_dict.Add("Cairo", "Cairo, Egypt’s sprawling capital, is set on the Nile River. At its heart is Tahrir Square and the vast Egyptian Museum, a trove of antiquities including royal mummies and gilded King Tutankhamun artifacts. Nearby, Giza is the site of the iconic pyramids and Great Sphinx, dating to the 26th century BC. In Gezira Island’s leafy Zamalek district, 187m Cairo Tower affords panoramic city views.");
        description_dict.Add("Sydney", "Sydney, capital of New South Wales and one of Australia's largest cities, is best known for its harbourfront Sydney Opera House, with a distinctive sail-like design. Massive Darling Harbour and the smaller Circular Quay port are hubs of waterside life, with the arched Harbour Bridge and esteemed Royal Botanic Garden nearby. Sydney Tower’s outdoor platform, the Skywalk, offers 360-degree views of the city and suburbs.");
        description_dict.Add("Shanghai", "Shanghai, on China’s central coast, is the country's biggest city and a global financial hub. Its heart is the Bund, a famed waterfront promenade lined with colonial-era buildings. Across the Huangpu River rises the Pudong district’s futuristic skyline, including 632m Shanghai Tower and the Oriental Pearl TV Tower, with distinctive pink spheres. Sprawling Yu Garden has traditional pavilions, towers and ponds.");
        description_dict.Add("Singapore", "Singapore, city, capital of the Republic of Singapore. It occupies the southern part of Singapore Island. Its strategic position on the strait between the Indian Ocean and South China Sea, complemented by its deepwater harbour, has made it the largest port in Southeast Asia and one of the world’s greatest commercial centres. The city, once a distinct entity, so came to dominate the island that the Republic of Singapore essentially became a city-state.");
        description_dict.Add("Seoul", "Seoul, the capital of South Korea, is a huge metropolis where modern skyscrapers, high-tech subways and pop culture meet Buddhist temples, palaces and street markets. Notable attractions include futuristic Dongdaemun Design Plaza, a convention hall with curving architecture and a rooftop park; Gyeongbokgung Palace, which once had more than 7,000 rooms; and Jogyesa Temple, site of ancient locust and pine trees.");
        description_dict.Add("Paris", "Paris, France's capital, is a major European city and a global center for art, fashion, gastronomy and culture. Its 19th-century cityscape is crisscrossed by wide boulevards and the River Seine. Beyond such landmarks as the Eiffel Tower and the 12th-century, Gothic Notre-Dame cathedral, the city is known for its cafe culture and designer boutiques along the Rue du Faubourg Saint-Honoré.");
        description_dict.Add("Milano", "Milan, a metropolis in Italy's northern Lombardy region, is a global capital of fashion and design. Home to the national stock exchange, it’s a financial hub also known for its high-end restaurants and shops. The Gothic Duomo di Milano cathedral and the Santa Maria delle Grazie convent, housing Leonardo da Vinci’s mural “The Last Supper,” testify to centuries of art and culture. ");
        description_dict.Add("Moscow", "Moscow, on the Moskva River in western Russia, is the nation’s cosmopolitan capital. In its historic core is the Kremlin, a complex that’s home to the president and tsarist treasures in the Armoury. Outside its walls is Red Square, Russia's symbolic center. It's home to Lenin’s Mausoleum, the State Historical Museum's comprehensive collection and St. Basil’s Cathedral, known for its colorful, onion-shaped domes.");
        description_dict.Add("Rio de Janeiro", "Rio de Janeiro is a huge seaside city in Brazil, famed for its Copacabana and Ipanema beaches, 38m Christ the Redeemer statue atop Mount Corcovado and for Sugarloaf Mountain, a granite peak with cable cars to its summit. The city is also known for its sprawling favelas (shanty towns). Its raucous Carnaval festival, featuring parade floats, flamboyant costumes and samba dancers, is considered the world’s largest.");
        description_dict.Add("New York", "New York City comprises 5 boroughs sitting where the Hudson River meets the Atlantic Ocean. At its core is Manhattan, a densely populated borough that’s among the world’s major commercial, financial and cultural centers. Its iconic sites include skyscrapers such as the Empire State Building and sprawling Central Park. Broadway theater is staged in neon-lit Times Square.");
        description_dict.Add("Oakland", "Oakland is a city on the east side of San Francisco Bay, in California. Jack London Square has a statue of the writer, who frequented the area. Nearby, Old Oakland features restored Victorian architecture and boutiques. Near Chinatown, the Oakland Museum of California covers state history, nature and art. Uptown contains the art deco Fox and Paramount theaters, restaurants, bars and galleries.");
        description_dict.Add("Mexico City", "Mexico City is the densely populated, high-altitude capital of Mexico. It's known for its Templo Mayor (a 13th-century Aztec temple), the baroque Catedral Metropolitana de México of the Spanish conquistadors and the Palacio Nacional, which houses historic murals by Diego Rivera. All of these are situated in and around the Plaza de la Constitución, the massive main square also known as the Zócalo.");
        description_dict.Add("Ottawa", "Ottawa is Canada’s capital, in the east of southern Ontario, near the city of Montréal and the U.S. border. Sitting on the Ottawa River, it has at its centre Parliament Hill, with grand Victorian architecture and museums such as the National Gallery of Canada, with noted collections of indigenous and other Canadian art. The park-lined Rideau Canal is filled with boats in summer and ice-skaters in winter.");
        description_dict.Add("London", "London, the capital of England and the United Kingdom, is a 21st-century city with history stretching back to Roman times. At its centre stand the imposing Houses of Parliament, the iconic ‘Big Ben’ clock tower and Westminster Abbey, site of British monarch coronations. Across the Thames River, the London Eye observation wheel provides panoramic views of the South Bank cultural complex, and the entire city.");

    }





    
    
}

public struct Location
    {
        public double Latitude;
        public double Longitude;

        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }


public static class NaviMath
    {
        private const double EARTH_RADIUS = 6378.137d; //km

        public static double Deg2Rad { get { return Math.PI / 180.0d; } }

        public static double LatlngDirection(Location from, Location to)
        {
            var dlat1 = from.Latitude * Deg2Rad;
            var dlng1 = from.Longitude * Deg2Rad;
            var dlat2 = to.Latitude * Deg2Rad;
            var dlng2 = to.Longitude * Deg2Rad;

            var deltaX = dlng2 - dlng1;
            var y = Math.Sin(deltaX);
            var x = Math.Cos(dlat1) * Math.Tan(dlat2) - Math.Sin(dlat1) * Math.Cos(deltaX);
            var dir = Math.Atan2(y, x) * 180 / Math.PI;
            if (dir < 0)
            {
                return 360 + dir;
            }
            return dir;
        }
    }