package com.swq.disastermonitoring;

import com.baidu.mapapi.BMapManager;
import com.baidu.mapapi.map.LocationData;
import com.baidu.mapapi.map.MapController;
import com.baidu.mapapi.map.MapView;
import com.baidu.mapapi.map.MyLocationOverlay;
import com.baidu.platform.comapi.basestruct.GeoPoint;
import android.app.Activity;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.Menu;
import java.util.TimerTask;
import java.util.Timer;

public class MainActivity extends Activity {
	private BMapManager mBMapMan = null;
	private MapView mMapView = null;
	private SharedPreferences preferences;
	private SharedPreferences.Editor editor;
	private String userId;

	private Intent intentLocation,intentAcc,intentCapt,intentPhotoUpload;
	private Timer timerLocal,timerActivity;
	
	private int flagActivity=0;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		
		intentLocation=new Intent(this,LocationService.class);
		intentAcc=new Intent(this,AccelerometerActivity.class);
		intentCapt=new Intent(this,CaptureImageActivity.class);
		intentPhotoUpload=new Intent(this,PhotoUploadActivity.class);
		
		this.startService(intentLocation);
		
		preferences = getSharedPreferences("PRIVATE", Activity.MODE_PRIVATE);
		editor=preferences.edit();
		userId = GetSerialNumber();//获取随机生成的序列号
		
		mBMapMan = new BMapManager(getApplication());
		mBMapMan.init("HGomeGAw8R5vGL9mwX8W99CC", null);

		// 注意：请在试用setContentView前初始化BMapManager对象，否则会报错
		setContentView(R.layout.activity_main);
		mMapView = (MapView) findViewById(R.id.bmapsView);
		mMapView.setBuiltInZoomControls(true);
		MapController mMapController = mMapView.getController();
		mMapController.setZoom(17);// 设置地图zoom级别
		
	    timerLocal = new Timer();
		timerLocal.schedule(taskLocal, 1 * 1000, 120 * 1000);
	}


	TimerTask taskLocal = new TimerTask() {
		@Override
		public void run() {
			//String userId = GetSerialNumber();//获取随机生成的序列号
			String str = GetPostUtil.sendPost(
					"http://222.66.97.54:8086/location/GetLastLocation",
					"userID=" + userId);
			String[] strArray = str.split(",");
			if (strArray.length == 3) {
				MyLocationOverlay myLocationOverlay = new MyLocationOverlay(
						mMapView);
				LocationData locData = new LocationData();
				locData.latitude = Double.parseDouble(strArray[0]);
				locData.longitude = Double.parseDouble(strArray[1]);

				myLocationOverlay.setData(locData);
				mMapView.getOverlays().add(myLocationOverlay);
				mMapView.refresh();
				mMapView.getController().animateTo(
						new GeoPoint((int) (locData.latitude * 1e6),
								(int) (locData.longitude * 1e6)));
			}
		}

	};
	@Override
	public void onResume()
	{
		super.onResume();
		TimerTask taskActivity = new TimerTask() {
			@Override
			public void run() {
				if(flagActivity==0)
				{
					startActivity(intentPhotoUpload);//intentAcc
					flagActivity=1;
				}
				else if(flagActivity==1)
				{
					startActivity(intentPhotoUpload);//intentCapt
					flagActivity=2;
				}
				else if(flagActivity==2)
				{
					startActivity(intentPhotoUpload);
					flagActivity=0;
				}
			}
		};
	    timerActivity = new Timer();
		timerActivity.schedule(taskActivity, 10 * 1000, 10 * 1000);
	}
	
	@Override
	public void onPause()
	{
		super.onPause();
		if(timerActivity!=null)
		{
		timerActivity.cancel();
		timerActivity=null;
		}
	}
	
	private String GetSerialNumber() {
		String serialNumber = preferences.getString("Serial_Number",  null);
		if (serialNumber == null) {
			serialNumber = Integer.toString((int) (Math.random() * 100000000));
			editor.putString("Serial_Number", serialNumber);
			editor.commit();
		}
		return serialNumber;
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}
}
