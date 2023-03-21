# DesignPattern
DesignPattern  
## 一，结构性  
### 1.1  适配器：类适配器和对象适配器。  
### 1.2 桥接模式  
> &emsp;使用抽象类继承接口，作为多维度桥梁
### 1.3 装饰器
> &emsp;装饰器和代理模式的区别：  
> * 代理模式是代码写死的，一旦写好，流程是固定的。  
> * 装饰器内容可以在使用的时候动态配置，内容客户可以动态调整。
### 1.4 组合模式
## 二，行为型  
###  2.1 策略模式（Strategy Pattern）  
```     
            // 使用策略模式前
			PromotionActivity promotionActivity;
			if ("无优惠".Equals(promotionType))
			{
				promotionActivity = new PromotionActivity(new EmptyPromotion());
			}
			else if ("团购".Equals(promotionType))
			{
				promotionActivity = new PromotionActivity(new GroupbuyPromotion());
			}
			else if ("优惠券".Equals(promotionType))
			{
				promotionActivity = new PromotionActivity(new CouponPromotion());
			}
			else if ("返现".Equals(promotionType))
			{
				promotionActivity = new PromotionActivity(new CashbackPromotion());
			}
			else {
				promotionActivity = new PromotionActivity(new EmptyPromotion());
			}
			promotionActivity.Execute();


			// 使用策略模式后
			IPromotion promotionStrategy = PromotionStrategyFactory.GetPromotion(promotionType);
			promotionStrategy.DoPromotion(); 
            

            // 策略工厂类   
            public class PromotionStrategyFactory
            {
                private static Dictionary<string, IPromotion> promotionDic = new Dictionary<string, IPromotion>()
                    {
                        {"现金", new CashbackPromotion() },
                        {"团购", new GroupbuyPromotion() },
                        {"优惠券", new CouponPromotion() },
                        {"无优惠", new EmptyPromotion() }
                    };

                /// <summary>
                /// 把优惠种类返回给前端，有策略增加或者变动，前端可以动态修改
                /// </summary>
                /// <returns></returns>
                public static HashSet<string> GetPromotionKeys() 
                {
                    return promotionDic.Keys.ToHashSet();
                }

                public static IPromotion GetPromotion(string promotionType) 
                {
                    if (promotionDic.ContainsKey(promotionType)) 
                    {
                        return promotionDic[promotionType];
                    }

                    return promotionDic["无优惠"];
                } 
            }
            
  
