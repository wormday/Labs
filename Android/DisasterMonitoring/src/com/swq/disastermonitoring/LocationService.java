package com.swq.disastermonitoring;

import android.app.Activity;
import android.app.Service;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.IBinder;
import com.baidu.location.LocationClient;
import com.baidu.location.LocationClientOption;


public class LocationService extends Service {

	public LocationClient mLocationClient = null;
	public MyLocationListener myListener = new MyLocationListener();
	SharedPreferences preferences;
	@Override
	public IBinder onBind(Intent arg0) {
		// TODO Auto-generated method stub
		return null;
	}
	
	@Override
	public void onCreate()
	{
		super.onCreate();
		System.out.println("LocationService is Created");
		
	    mLocationClient = new LocationClient(getApplicationContext());     //声明LocationClient类
	    mLocationClient.setAK("HGomeGAw8R5vGL9mwX8W99CC");
	    
	    
	    LocationClientOption option = new LocationClientOption();
	    option.setOpenGps(true);
	    //option.setAddrType("all");//返回的定位结果包含地址信息
	    option.setCoorType("bd09ll");//返回的定位结果是百度经纬度,默认值gcj02
	    option.setScanSpan(120*1000);//设置发起定位请求的间隔时间为5000ms
	    option.disableCache(true);//禁止启用缓存定位
	    option.setPoiNumber(5);    //最多返回POI个数   
	    option.setPoiDistance(1000); //poi查询距离        
	    option.setPoiExtraInfo(true); //是否需要POI的电话和地址等详细信息        
	    mLocationClient.setLocOption(option);
	    preferences=getSharedPreferences("PRIVATE",Activity.MODE_PRIVATE);
	    myListener.userId=preferences.getString("Serial_Number", "unknow");
	    mLocationClient.registerLocationListener( myListener );
	    
	}
	
	@Override
	public int onStartCommand(Intent intent,int flags,int startId)
	{
		mLocationClient.start();
		if (mLocationClient != null && mLocationClient.isStarted())
			mLocationClient.requestLocation();
		else 
			System.out.println("mLocationClient is null or not started");
		
		System.out.println("LocationService is Started");
		return START_STICKY;
	}
	
	@Override
	public void onDestroy()
	{
		super.onDestroy();
		mLocationClient.stop();
		System.out.println("LocationService is Destroyed");
	}

}
